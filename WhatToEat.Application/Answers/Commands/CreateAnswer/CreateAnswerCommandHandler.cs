using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WhatToEat.Domain.Exceptions;
using WhatToEat.Domain.Repositories;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Answers.Commands.CreateAnswer;

public class CreateAnswerCommandHandler(ILogger<CreateAnswerCommandHandler> logger,
    IMapper mapper,
    IWhatToEatRepository whatToEatRepository,
    IAnswerRepository answerRepository) : IRequestHandler<CreateAnswerCommand>
{
    public async Task Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new answer {@Answer}", request);
        var question = await whatToEatRepository.GetQuestionByIdAsync(request.QuestionId);
        if(question is null)
            throw new NotFoundException(nameof(Question), request.QuestionId.ToString());
        var answer = mapper.Map<Answer>(request);
        await answerRepository.Create(answer);
    }
}
