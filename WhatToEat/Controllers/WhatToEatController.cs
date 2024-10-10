using MediatR;
using Microsoft.AspNetCore.Authorization;
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
[Authorize]
public class WhatToEatController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetAllQuestions()
    {
        var questions = await mediator.Send(new GetAllQuestionsQuery());
        return Ok(questions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionDto>> GetQuestionById([FromRoute] int id)
    {
        var question = await mediator.Send(new GetQuestionByIdQuery(id));
        
        return Ok(question);
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(actionName: nameof(this.GetQuestionById), routeValues: new { id }, value: null);
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteQuestion([FromRoute] int id)
    {
        await mediator.Send(new DeleteQuestionCommand(id));
        return NoContent();
    }


    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateQuestion([FromRoute] int id, [FromBody] UpdateQuestionCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }
}
