
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Answers.Dtos;

public class AnswerDto
{
    public int Id { get; set; }
    public string Text { get; set; } = default!;
}
