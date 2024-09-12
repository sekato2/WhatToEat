using WhatToEat.Domains.Entities;

namespace WhatToEat.Domain.Repositories;

public interface IWhatToEatRepository
{
    Task<IEnumerable<Question>> GetAllQuestionsAsync(); 
}
