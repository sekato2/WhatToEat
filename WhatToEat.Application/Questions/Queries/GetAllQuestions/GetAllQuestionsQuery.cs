using MediatR;
using WhatToEat.Application.Questions.Dtos;

namespace WhatToEat.Application.Questions.Queries.GetAllQuestions;

public class GetAllQuestionsQuery : IRequest<IEnumerable<QuestionDto>>
{
}
