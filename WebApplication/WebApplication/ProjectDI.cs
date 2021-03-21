using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Helpers;

namespace WebApplication
{
    public static class ProjectDI
    {
        public static IServiceCollection AddProjectDI(this IServiceCollection services)
        {
            // Library
            services.AddSingleton<ICommonHelper, CommonHelper>();

            return services;
        }
    }
}
