using FluentValidation;
using WhatToEat.Application.Questions.Dtos;

namespace WhatToEat.Application.Questions.Validators;

public class CreateQuestionDtoValidator : AbstractValidator<CreateQuestionDto>
{
    public CreateQuestionDtoValidator()
    {
        RuleFor(dto => dto.Text)
            .Must(y => !new ProfanityFilter.ProfanityFilter().ContainsProfanity(y))
            .WithMessage("The question contains one or more inappropriate words. Please review and edit the content before submitting.");
    }
}
