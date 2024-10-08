using MediatR;
using WhatToEat.Application.Answers.Dtos;

namespace WhatToEat.Application.Answers.Queries.GetByIdForQuestion;

public class GetByIdForQuestionQuery(int questionId, int answerId) : IRequest<AnswerDto>
{
    public int QuestionId { get; } = questionId;
    public int AnswerId { get; } = answerId;
}
