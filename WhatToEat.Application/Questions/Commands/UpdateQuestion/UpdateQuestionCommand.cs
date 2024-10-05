using MediatR;

namespace WhatToEat.Application.Questions.Commands.UpdateQuestion;

public class UpdateQuestionCommand() : IRequest<bool>
{
    public int Id { get; set;  }

    public string Text { get; set; } = default!;
}
