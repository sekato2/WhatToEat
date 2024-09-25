using Microsoft.EntityFrameworkCore;
using WhatToEat.Domain.Repositories;
using WhatToEat.Domains.Entities;
using WhatToEat.Infrastructure.Persistence;

namespace WhatToEat.Infrastructure.Repositories;

internal class WhatToEatRepository(WhatToEatDbContext dbContext) : IWhatToEatRepository
{
    public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
    {
        var questions = await dbContext.Questions.ToListAsync();
        return questions;
    }

    public async Task<Question?> GetQuestionByIdAsync(int id)
    {
        var question = await dbContext.Questions
            .Include(y => y.Answers)
            .FirstOrDefaultAsync(x => x.Id == id);
        return question;
    }
}
