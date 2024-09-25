using Microsoft.Extensions.Logging;
using System.Data;
using WhatToEat.Application.Questions.Dtos;
using WhatToEat.Domain.Repositories;

namespace WhatToEat.Application.Questions;

internal class QuestionsService(IWhatToEatRepository whatToEatRepository,
    ILogger<QuestionsService> logger) : IQuestionsService
{
    public async Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync()
    {
        logger.LogInformation("Getting all questions");
        var questions = await whatToEatRepository.GetAllQuestionsAsync();
        var questionsDtos = questions.Select(QuestionDto.FromEntity).ToList();
        return questionsDtos!;
    }

    public async Task<QuestionDto?> GetQuestionByIdAsync(int id)
    {
        logger.LogInformation("Getting question by id " + id);
        var question = await whatToEatRepository.GetQuestionByIdAsync(id);
        var questionDtos = QuestionDto.FromEntity(question);
        return questionDtos;
    }
}
