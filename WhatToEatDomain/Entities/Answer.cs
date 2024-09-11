namespace WhatToEat.Domains.Entities;

public class Answer
{
    public int Id { get; set; }
    public string Text { get; set; } = default!;
    public int QuestionId { get; set; } = default!;
}
