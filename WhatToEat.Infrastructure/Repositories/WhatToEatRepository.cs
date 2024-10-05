using Microsoft.EntityFrameworkCore;
using WhatToEat.Domain.Repositories;
using WhatToEat.Domains.Entities;
using WhatToEat.Infrastructure.Persistence;

namespace WhatToEat.Infrastructure.Repositories;

internal class WhatToEatRepository(WhatToEatDbContext dbContext) : IWhatToEatRepository
{
    public async Task<int> Create(Question entity)
    {
        dbContext.Questions.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task Delete(Question question)
    {
        dbContext.Remove(question);
        await dbContext.SaveChangesAsync();
    }

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

    public Task SaveChanges() => dbContext.SaveChangesAsync();
}
