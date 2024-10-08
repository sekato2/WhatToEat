﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WhatToEat.Application.Answers.Commands.CreateAnswer;
using WhatToEat.Application.Answers.Dtos;
using WhatToEat.Application.Answers.Queries.GetAllForQuestion;
using WhatToEat.Application.Answers.Queries.GetByIdForQuestion;
using WhatToEat.Application.Questions.Queries.GetAllQuestions;
using WhatToEat.Domains.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WhatToEat.API.Controllers;

[ApiController]
[Route("api/whatToEat/{questionId}/Answer")]
public class AnswersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAnswer([FromRoute] int questionId, [FromBody] CreateAnswerCommand command)
    {
        command.QuestionId = questionId;
        await mediator.Send(command);
        return Created();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AnswerDto>>> GetAllForQuestion([FromRoute] int questionId)
    {
        var answers = await mediator.Send(new GetAllForQuestionQuery(questionId));
        return Ok(answers);
    }

    [HttpGet("{answerId}")]
    public async Task<ActionResult<AnswerDto>> GetByIdForQuestion([FromRoute] int questionId, [FromRoute]int answerId)
    {
        var answer = await mediator.Send(new GetByIdForQuestionQuery(questionId, answerId));
        return Ok(answer);
    }
}
