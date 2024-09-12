using Microsoft.Extensions.DependencyInjection;
using WhatToEat.Application.WhatToEat;

namespace WhatToEat.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IWhatToEatServices, WhatToEatServices>();
    }
}
