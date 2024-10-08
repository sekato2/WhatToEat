﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhatToEat.Domain.Entities;
using WhatToEat.Domain.Repositories;
using WhatToEat.Infrastructure.Persistence;
using WhatToEat.Infrastructure.Repositories;
using WhatToEat.Infrastructure.Seeders;

namespace WhatToEat.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("WhatToEatDb");
        services.AddDbContext<WhatToEatDbContext>(options => 
            options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging());

        services.AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<WhatToEatDbContext>();

        services.AddScoped<IWhatToEatSeeder, WhatToEatSeeder>();
        services.AddScoped<IWhatToEatRepository, WhatToEatRepository>();
        services.AddScoped<IAnswerRepository, AnswerRepository>();
    }
}
