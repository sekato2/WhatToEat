using WhatToEat.Domains.Entities;

namespace WhatToEat.Domain.Repositories;

public interface IAnswerRepository
{
    Task<int> Create(Answer answer);
}
