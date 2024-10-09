using MediatR;

namespace WhatToEat.Application.Answers.Commands.DeleteAnswers;

public class DeleteAnswersCommand(int questionId) : IRequest
{
    public int QuestionId { get; } = questionId;
}
