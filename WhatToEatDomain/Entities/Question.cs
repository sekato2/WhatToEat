namespace WhatToEat.Domains.Entities;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; } = default!;
    public List<Answer> Answers { get; set; } = new();
}
