using MediatR;
using Microsoft.Extensions.Logging;
using WhatToEat.Domain.Exceptions;
using WhatToEat.Domain.Repositories;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Questions.Commands.DeleteQuestion;

public class DeleteQuestionCommandHandler(ILogger<DeleteQuestionCommandHandler> logger,
    IWhatToEatRepository whatToEatRepository) : IRequestHandler<DeleteQuestionCommand>
{
    public async Task Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting question with id: {QuestionId}", request.Id);
        var question = await whatToEatRepository.GetQuestionByIdAsync(request.Id);
        if (question is null)
            throw new NotFoundException(nameof(Question), request.Id.ToString());
        
        await whatToEatRepository.Delete(question);
    }
}
