using WhatToEat.Domains.Entities;

namespace WhatToEat.Domain.Repositories;

public interface IWhatToEatRepository
{
    Task<IEnumerable<Question>> GetAllQuestionsAsync();
    Task<Question?> GetQuestionByIdAsync(int id);
    Task<int> Create(Question question);
    Task Delete(Question question);
    Task SaveChanges();
}
