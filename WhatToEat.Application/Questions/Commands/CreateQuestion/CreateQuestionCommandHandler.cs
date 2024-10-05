using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WhatToEat.Application.Questions.Dtos;
using WhatToEat.Domain.Repositories;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Questions.Commands.CreateQuestion;

public class CreateQuestionCommandHandler(ILogger<CreateQuestionCommandHandler> logger,
    IMapper mapper,
    IWhatToEatRepository whatToEatRepository) : IRequestHandler<CreateQuestionCommand, int>
{
    public async Task<int> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new question {@Question}", request);
        var question = mapper.Map<Question>(request);
        int id = await whatToEatRepository.Create(question);
        return id;
    }
}
