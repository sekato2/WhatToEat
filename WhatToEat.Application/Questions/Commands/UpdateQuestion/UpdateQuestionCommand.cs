using MediatR;

namespace WhatToEat.Application.Questions.Commands.UpdateQuestion;

public class UpdateQuestionCommand() : IRequest
{
    public int Id { get; set;  }

    public string Text { get; set; } = default!;
}
