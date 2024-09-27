using Microsoft.Extensions.DependencyInjection;
using WhatToEat.Application.Questions;

namespace WhatToEat.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IQuestionsService, QuestionsService>();

        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
    }
}
