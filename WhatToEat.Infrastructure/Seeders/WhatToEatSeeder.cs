using WhatToEat.Domains.Entities;
using WhatToEat.Infrastructure.Persistence;

namespace WhatToEat.Infrastructure.Seeders;

internal class WhatToEatSeeder(WhatToEatDbContext dbContext) : IWhatToEatSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!(dbContext.Dishes.Any() && dbContext.Questions.Any()))
            {
                var answers = GetAnswers();
                var questions = GetQuestions(answers);
                var dishes = GetDishes(answers);

                dbContext.Questions.AddRange(questions);
                dbContext.Dishes.AddRange(dishes);

                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Answer> GetAnswers()
    {
        List<Answer> Answers = [
            new(){ Text = "Cocinar" },
            new(){ Text = "Ordenar" },
            new(){ Text = "De 10 a 30 minutos" },
            new(){ Text = "De 30 a 60 minutos" },
            new(){ Text = "Más de 60 minutos" },
            new(){ Text = "Poco" },
            new(){ Text = "Moderado" },
            new(){ Text = "Mucho" }
        ];

        return Answers;
    }


    private IEnumerable<Question> GetQuestions(IEnumerable<Answer> answers)
    {
        List<Question> questions = [
            new()
            {
                Text = "Cocinar u ordenar",
                Answers =
                [
                    answers.ElementAt(0),
                    answers.ElementAt(1),
                ],

            },
            new()
            {
                Text = "Cuanto tiempo dispone",
                Answers =
                [
                    answers.ElementAt(2),
                    answers.ElementAt(3),
                    answers.ElementAt(4),
                ],

            },
            new()
            {
                Text = "Nivel de picante",
                Answers =
                [
                    answers.ElementAt(5),
                    answers.ElementAt(6),
                    answers.ElementAt(7),
                ],

            },
        ];

        return questions;
    }
    private IEnumerable<Dish> GetDishes(IEnumerable<Answer> answers)
    {
        List<Dish> dishes = [
            new()
            {
                Name = "Tacos",
                Answers =
                [
                    answers.ElementAt(1),
                    answers.ElementAt(4),
                    answers.ElementAt(7),
                ],
            },
            new()
            {
                Name = "Hamburguesa",
                Answers =  [
                    answers.ElementAt(1),
                    answers.ElementAt(2),
                    answers.ElementAt(5),
                ]
            },
            new()
            {
                Name = "Sandwich",
                Answers =  [
                    answers.ElementAt(0),
                    answers.ElementAt(3),
                    answers.ElementAt(6),
                ]
            }
        ];

        return dishes;
    }
}
