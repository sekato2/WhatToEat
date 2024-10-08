﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WhatToEat.Domain.Entities;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Infrastructure.Persistence;

internal class WhatToEatDbContext(DbContextOptions<WhatToEatDbContext> options) 
    : IdentityDbContext<User>(options)
{
    internal DbSet<Question> Questions { get; set; }
    internal DbSet<Answer> Answers { get; set; }
    internal DbSet<Dish> Dishes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Dish>()
            .HasMany(y => y.Answers)
            .WithMany();

        modelBuilder.Entity<Question>()
            .HasMany(y => y.Answers)
            .WithOne()
            .HasForeignKey(x => x.QuestionId);

    }
}
