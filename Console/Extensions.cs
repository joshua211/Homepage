using System;
using homepage.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace homepage.Console
{
    public static class Extensions
    {
        public static IServiceCollection AddCommand<T>(this IServiceCollection services) where T : class, IConsoleCommand
        {
            return services.AddTransient<IConsoleCommand, T>();
        }
    }
}