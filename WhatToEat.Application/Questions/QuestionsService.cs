using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Data;
using WhatToEat.Application.Questions.Dtos;
using WhatToEat.Domain.Repositories;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Questions;

internal class QuestionsService(IWhatToEatRepository whatToEatRepository,
    ILogger<QuestionsService> logger,
    IMapper mapper) : IQuestionsService
{
    public async Task<int> Create(CreateQuestionDto questionDto)
    {
        logger.LogInformation("Creating a new question");

        var question = mapper.Map<Question>(questionDto);

        int id = await whatToEatRepository.Create(question);
        return id;
    }

    public async Task<IEnumerable<QuestionDto>> GetAllQuestions()
    {
        logger.LogInformation("Getting all questions");
        var questions = await whatToEatRepository.GetAllQuestionsAsync();

        var questionsDtos = mapper.Map<IEnumerable<QuestionDto>>(questions);

        return questionsDtos!;
    }

    public async Task<QuestionDto?> GetQuestionById(int id)
    {
        logger.LogInformation("Getting question by id " + id);
        var question = await whatToEatRepository.GetQuestionByIdAsync(id);
        var questionDtos = mapper.Map<QuestionDto?>(question);
        return questionDtos;
    }
}
