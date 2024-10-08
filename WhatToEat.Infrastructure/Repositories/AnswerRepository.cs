using Microsoft.EntityFrameworkCore;
using WhatToEat.Domain.Repositories;
using WhatToEat.Domains.Entities;
using WhatToEat.Infrastructure.Persistence;

namespace WhatToEat.Infrastructure.Repositories;

internal class AnswerRepository(WhatToEatDbContext dbContext) : IAnswerRepository
{
    public async Task<int> Create(Answer answer)
    {
        dbContext.Answers.Add(answer);
        await dbContext.SaveChangesAsync();
        return answer.Id;
    }
}
