using MediatR;

namespace WhatToEat.Application.Questions.Commands.DeleteQuestion;

public class DeleteQuestionCommand(int id) : IRequest
{
    public int Id { get; } = id;
}
