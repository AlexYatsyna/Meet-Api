using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MeetUp.Logic
{
    public static class DI
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
