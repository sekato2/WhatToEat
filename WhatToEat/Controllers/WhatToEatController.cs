using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WhatToEat.Application.Questions;
using WhatToEat.Application.Questions.Commands.CreateQuestion;
using WhatToEat.Application.Questions.Commands.DeleteQuestion;
using WhatToEat.Application.Questions.Commands.UpdateQuestion;
using WhatToEat.Application.Questions.Dtos;
using WhatToEat.Application.Questions.Queries.GetAllQuestions;
using WhatToEat.Application.Questions.Queries.GetQuestionById;

namespace WhatToEat.API.Controllers;

[ApiController]
[Route("api/whatToEat")]
public class WhatToEatController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllQuestions()
    {
        var questions = await mediator.Send(new GetAllQuestionsQuery());
        return Ok(questions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuestionById([FromRoute] int id)
    {
        var question = await mediator.Send(new GetQuestionByIdQuery(id));
        if (question is null)
        {
            return NotFound();
        }
        return Ok(question);
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(actionName: nameof(this.GetQuestionById), routeValues: new { id }, value: null);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuestion([FromRoute] int id)
    {
        bool isDeleted = await mediator.Send(new DeleteQuestionCommand(id));
        if (isDeleted)
            return NoContent();

        return NotFound();
    }


    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateQuestion([FromRoute] int id, [FromBody] UpdateQuestionCommand command)
    {
        command.Id = id;
        bool isUpdated = await mediator.Send(command);
        if (isUpdated)
            return NoContent();

        return NotFound();
    }
}
