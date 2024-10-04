using MediatR;
using System.ComponentModel.DataAnnotations;

namespace WhatToEat.Application.Questions.Commands.CreateQuestion;

public class CreateQuestionCommand : IRequest<int>
{
    [StringLength(500, MinimumLength = 10)]
    public string Text { get; set; } = default!;
}
