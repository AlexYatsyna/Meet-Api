using MeetUp.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MeetUp.Infrastructure
{
    public static class DI
    {
        public static IServiceCollection AddDB(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EventDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddScoped<IEventDbContext>(provider => provider.GetService<EventDbContext>());
            return services;
        }
    }
}
