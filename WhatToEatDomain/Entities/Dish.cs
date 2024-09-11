namespace WhatToEat.Domains.Entities;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public List<Answer> Answers { get; set; } = new();
}
