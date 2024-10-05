using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WhatToEat.Application.Questions.Dtos;
using WhatToEat.Domain.Exceptions;
using WhatToEat.Domain.Repositories;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Questions.Queries.GetQuestionById;

public class GetQuestionByIdQueryHandler(ILogger<GetQuestionByIdQueryHandler> logger,
    IMapper mapper,
    IWhatToEatRepository whatToEatRepository) : IRequestHandler<GetQuestionByIdQuery, QuestionDto>
{
    public async Task<QuestionDto> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting question by id: {QuestionId}", request.Id);
        var question = await whatToEatRepository.GetQuestionByIdAsync(request.Id) 
            ?? throw new NotFoundException(nameof(Question), request.Id.ToString());
        var questionDtos = mapper.Map<QuestionDto>(question);
        return questionDtos;
    }
}
