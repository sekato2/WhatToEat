using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WhatToEat.Domain.Exceptions;
using WhatToEat.Domain.Repositories;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Questions.Commands.UpdateQuestion;

public class UpdateQuestionCommandHandler(ILogger<UpdateQuestionCommandHandler> logger,
    IWhatToEatRepository whatToEatRepository,
    IMapper mapper) : IRequestHandler<UpdateQuestionCommand>
{
    public async Task Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating question with id: {QuestionId} with {@UpdatedQuestion}", request.Id, request);
        var question = await whatToEatRepository.GetQuestionByIdAsync(request.Id);
        if (question is null)
            throw new NotFoundException(nameof(Question), request.Id.ToString());

        mapper.Map(request, question);
        await whatToEatRepository.SaveChanges();
    }
}
