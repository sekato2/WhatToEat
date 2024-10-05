using FluentValidation;

namespace WhatToEat.Application.Questions.Commands.UpdateQuestion;

public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
{
    public UpdateQuestionCommandValidator()
    {
        RuleFor(dto => dto.Text).Length(10, 500);
        RuleFor(dto => dto.Text)
            .Must(y => !new ProfanityFilter.ProfanityFilter().ContainsProfanity(y))
            .WithMessage("The question contains one or more inappropriate words. Please review and edit the content before submitting.");
    }
}
