using FluentValidation;
using WhatToEat.Application.Questions.Dtos;

namespace WhatToEat.Application.Questions.Commands.CreateQuestion;

public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator()
    {
        RuleFor(dto => dto.Text)
            .Must(y => !new ProfanityFilter.ProfanityFilter().ContainsProfanity(y))
            .WithMessage("The question contains one or more inappropriate words. Please review and edit the content before submitting.");
    }
}
