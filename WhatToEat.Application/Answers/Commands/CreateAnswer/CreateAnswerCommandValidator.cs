using FluentValidation;

namespace WhatToEat.Application.Answers.Commands.CreateAnswer;

public class CreateAnswerCommandValidator : AbstractValidator<CreateAnswerCommand>
{
    public CreateAnswerCommandValidator()
    {
        RuleFor(dto => dto.Text)
                .Must(y => !new ProfanityFilter.ProfanityFilter().ContainsProfanity(y))
                .WithMessage("The question contains one or more inappropriate words. Please review and edit the content before submitting.");

        RuleFor(dto => dto.Text).Length(3, 50);
    }
}
