using WhatToEat.Application.Answers.Dtos;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Questions.Dtos;

public class QuestionDto
{
    public int Id { get; set; }
    public string Text { get; set; } = default!;
    public List<AnswerDto> Answers { get; set; } = [];

    public static QuestionDto? FromEntity(Question? question)
    {
        if (question == null) return null;

        return new QuestionDto
        {
            Id = question.Id,
            Text = question.Text,
            Answers = question.Answers.Select(AnswerDto.FromEntity).ToList(),
        };
    }
}
