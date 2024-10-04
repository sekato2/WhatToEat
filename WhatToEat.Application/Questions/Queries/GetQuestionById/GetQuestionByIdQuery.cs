using MediatR;
using WhatToEat.Application.Questions.Dtos;

namespace WhatToEat.Application.Questions.Queries.GetQuestionById;

public class GetQuestionByIdQuery(int id) : IRequest<QuestionDto?>
{
    public int Id { get; } = id;
}
