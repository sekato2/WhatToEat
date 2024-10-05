using MediatR;
using Microsoft.Extensions.Logging;
using WhatToEat.Domain.Repositories;

namespace WhatToEat.Application.Questions.Commands.DeleteQuestion;

public class DeleteQuestionCommandHandler(ILogger<DeleteQuestionCommandHandler> logger,
    IWhatToEatRepository whatToEatRepository) : IRequestHandler<DeleteQuestionCommand, bool>
{
    public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting question with id : {request.Id}");
        var question = await whatToEatRepository.GetQuestionByIdAsync(request.Id);
        if (question is null)
            return false;
        
        await whatToEatRepository.Delete(question);
        return true;
    }
}
