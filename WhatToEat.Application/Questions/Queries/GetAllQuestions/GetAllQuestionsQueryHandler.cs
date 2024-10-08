using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WhatToEat.Application.Questions.Dtos;
using WhatToEat.Domain.Repositories;

namespace WhatToEat.Application.Questions.Queries.GetAllQuestions;

public class GetAllQuestionsQueryHandler(ILogger<GetAllQuestionsQueryHandler> logger,
    IMapper mapper,
    IWhatToEatRepository whatToEatRepository) : IRequestHandler<GetAllQuestionsQuery, IEnumerable<QuestionDto>>
{
    public async Task<IEnumerable<QuestionDto>> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all answers");
        var questions = await whatToEatRepository.GetAllQuestionsAsync();
        var questionsDtos = mapper.Map<IEnumerable<QuestionDto>>(questions);
        return questionsDtos!;
    }
}
