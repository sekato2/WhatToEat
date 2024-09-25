using WhatToEat.Application.Questions.Dtos;

namespace WhatToEat.Application.Questions
{
    public interface IQuestionsService
    {
        Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync();
        Task<QuestionDto?> GetQuestionByIdAsync(int id);
    }
}