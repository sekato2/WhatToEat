using System.ComponentModel.DataAnnotations;

namespace WhatToEat.Application.Questions.Dtos;

public class CreateQuestionDto
{
    [StringLength(500, MinimumLength = 10)]
    public string Text { get; set; } = default!;
}
