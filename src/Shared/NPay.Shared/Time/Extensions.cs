using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace NPay.Shared.Time
{
    internal static class Extensions
    {
        public static IServiceCollection AddClock(this IServiceCollection services)
        {
            services.AddSingleton<IClock, UtcClock>();
            return services;
        }
    }
}
