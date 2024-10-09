using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WhatToEat.Domain.Exceptions;
using WhatToEat.Domain.Repositories;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Answers.Commands.DeleteAnswers;

public class DeleteAnswersCommandHandler (ILogger<DeleteAnswersCommandHandler> logger,
    IWhatToEatRepository whatToEatRepository,
    IMapper mapper) : IRequestHandler<DeleteAnswersCommand>
{
    public async Task Handle(DeleteAnswersCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Deleting all asnwers for question with id: {@QuestionId}", request.QuestionId);
        var question = await whatToEatRepository.GetQuestionByIdAsync(request.QuestionId);
        if (question == null)
            throw new NotFoundException(nameof(Question), request.QuestionId.ToString());

        question.Answers.Clear();
        await whatToEatRepository.SaveChanges();
    }
}
