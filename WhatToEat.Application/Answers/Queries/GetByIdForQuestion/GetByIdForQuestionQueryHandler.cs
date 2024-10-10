using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WhatToEat.Application.Answers.Dtos;
using WhatToEat.Domain.Exceptions;
using WhatToEat.Domain.Repositories;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Answers.Queries.GetByIdForQuestion;

public class GetByIdForQuestionQueryHandler(ILogger<GetByIdForQuestionQueryHandler> logger,
    IWhatToEatRepository whatToEatRepository,
    IMapper mapper) : IRequestHandler<GetByIdForQuestionQuery, AnswerDto>
{
    public async Task<AnswerDto> Handle(GetByIdForQuestionQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get answers for question id: {@QuestionId} and answer id: {@AnswerId}", request.QuestionId, request.AnswerId);
        var question = await whatToEatRepository.GetQuestionByIdAsync(request.QuestionId);
        if (question is null)
            throw new NotFoundException(nameof(Question), request.QuestionId.ToString());

        var answer = question.Answers.FirstOrDefault(y => y.Id  == request.AnswerId);
        if (answer is null)
            throw new NotFoundException(nameof(Answer), request.AnswerId.ToString());
        var answerDto = mapper.Map<AnswerDto>(answer);
        return answerDto;
    }
}
