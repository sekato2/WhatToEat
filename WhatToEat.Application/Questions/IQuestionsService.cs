using WhatToEat.Application.Questions.Dtos;

namespace WhatToEat.Application.Questions
{
    public interface IQuestionsService
    {
        Task<IEnumerable<QuestionDto>> GetAllQuestions();
        Task<QuestionDto?> GetQuestionById(int id);
        Task<int> Create(CreateQuestionDto questionDto);
    }
}