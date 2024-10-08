using MediatR;
using WhatToEat.Application.Answers.Dtos;

namespace WhatToEat.Application.Answers.Queries.GetAllForQuestion;

public class GetAllForQuestionQuery(int questionId) : IRequest<IEnumerable<AnswerDto>>
{
    public int QuestionId { get; } = questionId;
}
