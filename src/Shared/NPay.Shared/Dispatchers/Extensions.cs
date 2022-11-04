using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPay.Shared.Dispatchers
{
    internal static class Extensions
    {
        public static IServiceCollection AddDispatchers(this IServiceCollection services)
        {
            services.AddSingleton<IDispatcher, InMemoryDispatcher>();
            return services;
        }
    }
}
