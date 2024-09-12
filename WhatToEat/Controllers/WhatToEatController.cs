using Microsoft.AspNetCore.Mvc;
using WhatToEat.Application.WhatToEat;

namespace WhatToEat.API.Controllers;

[ApiController]
[Route("api/whatToEat")]
public class WhatToEatController(IWhatToEatServices whatToEatServices) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllQuestionsAsync()
    {
        var questions = await whatToEatServices.GetAllQuestionsAsync();
        return Ok(questions);
    }
}
