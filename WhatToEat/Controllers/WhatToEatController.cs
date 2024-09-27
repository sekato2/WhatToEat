using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WhatToEat.Application.Questions;
using WhatToEat.Application.Questions.Dtos;

namespace WhatToEat.API.Controllers;

[ApiController]
[Route("api/whatToEat")]
public class WhatToEatController(IQuestionsService whatToEatServices) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllQuestions()
    {
        var questions = await whatToEatServices.GetAllQuestions();
        return Ok(questions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuestionByIdOtro([FromRoute] int id)
    {
        var question = await whatToEatServices.GetQuestionById(id);
        if (question is null)
        {
            return NotFound();
        }
        return Ok(question);
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionDto createQuestionDto)
    {
        int id = await whatToEatServices.Create(createQuestionDto);
        return CreatedAtAction(actionName: nameof(this.GetQuestionByIdOtro), routeValues: new { id }, value: null);
    }
}
