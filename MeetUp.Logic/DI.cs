using FluentValidation;
using MediatR;
using MeetUp.Logic.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MeetUp.Logic
{
    public static class DI
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            return services;
        }
    }
}
