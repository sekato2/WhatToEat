using WhatToEat.Application.Answers.Dtos;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Questions.Dtos;

public class QuestionDto
{
    public int Id { get; set; }
    public string Text { get; set; } = default!;
    public List<AnswerDto> Answers { get; set; } = [];
}
