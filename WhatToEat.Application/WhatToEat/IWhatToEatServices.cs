using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.WhatToEat
{
    public interface IWhatToEatServices
    {
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
    }
}