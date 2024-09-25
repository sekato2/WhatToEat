using Microsoft.AspNetCore.Mvc;
using WhatToEat.Application.Questions;

namespace WhatToEat.API.Controllers;

[ApiController]
[Route("api/whatToEat")]
public class WhatToEatController(IQuestionsService whatToEatServices) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllQuestionsAsync()
    {
        var questions = await whatToEatServices.GetAllQuestionsAsync();
        return Ok(questions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuestionsByIdAsync([FromRoute] int id)
    {
        var question = await whatToEatServices.GetQuestionByIdAsync(id);
        if (question is null)
        {
            return NotFound();
        }
        return Ok(question);
    }
}
