using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WhatToEat.Application.Answers.Dtos;
using WhatToEat.Application.Questions.Dtos;
using WhatToEat.Domain.Exceptions;
using WhatToEat.Domain.Repositories;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Answers.Queries.GetAllForQuestion;

public class GetAllForQuestionQueryHandler (ILogger<GetAllForQuestionQueryHandler> logger,
    IWhatToEatRepository whatToEatRepository,
    IMapper mapper) : IRequestHandler<GetAllForQuestionQuery, IEnumerable<AnswerDto>>
{
    public async Task<IEnumerable<AnswerDto>> Handle(GetAllForQuestionQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get answers for question id: {@QuestionId}", request.QuestionId);
        var question = await whatToEatRepository.GetQuestionByIdAsync(request.QuestionId);
        if (question is null)
            throw new NotFoundException(nameof(Question), request.QuestionId.ToString());

        var answers = mapper.Map<IEnumerable<AnswerDto>>(question.Answers);
        return answers!;
    }
}
