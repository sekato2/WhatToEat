using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WhatToEat.Domain.Repositories;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Questions.Commands.UpdateQuestion;

public class UpdateQuestionCommandHandler(ILogger<UpdateQuestionCommandHandler> logger,
    IWhatToEatRepository whatToEatRepository,
    IMapper mapper) : IRequestHandler<UpdateQuestionCommand, bool>
{
    public async Task<bool> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating question with id: {request.Id}");
        var question = await whatToEatRepository.GetQuestionByIdAsync(request.Id);
        if (question is null)
            return false;

        mapper.Map(request, question);
        await whatToEatRepository.SaveChanges();
        return true;
    }
}
