using Microsoft.Extensions.Logging;
using WhatToEat.Domain.Repositories;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.WhatToEat;

internal class WhatToEatServices(IWhatToEatRepository whatToEatRepository,
    ILogger<WhatToEatServices> logger) : IWhatToEatServices
{
    public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
    {
        logger.LogInformation("Getting all questions");
        var questions = await whatToEatRepository.GetAllQuestionsAsync();
        return questions;
    }
}
