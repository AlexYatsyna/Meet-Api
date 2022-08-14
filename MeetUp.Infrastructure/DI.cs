﻿using MeetUp.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeetUp.Infrastructure
{
    public static class DI
    {
        public static IServiceCollection AddDB(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<EventDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddScoped<IEventDbContext>(provider => provider.GetService<EventDbContext>());
            return services;
        }
    }
}