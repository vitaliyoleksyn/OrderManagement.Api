using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using FluentValidation;
using Albelli.OrderManagement.Application.Common.Behavior;
using Albelli.OrderManagement.Application.Interfaces;

namespace Albelli.OrderManagement.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly()});
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddSingleton<IPackageWidthCalculator, PackageWidthCalculator>();

            return services;
        }
    }
}
