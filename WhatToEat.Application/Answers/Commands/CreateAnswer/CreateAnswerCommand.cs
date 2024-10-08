using MediatR;

namespace WhatToEat.Application.Answers.Commands.CreateAnswer;

public class CreateAnswerCommand: IRequest
{
    public string Text { get; set; } = default!;
    public int QuestionId { get; set; }
}
