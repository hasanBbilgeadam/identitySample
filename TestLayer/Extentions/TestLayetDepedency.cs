using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLayer.Managers;
using TestLayer.Services;

namespace TestLayer.Extentions
{
    public static class TestLayetDepedency
    {

        public static void AddTestLayetDependency(this IServiceCollection services )
        {

            services.AddScoped<ICustomService, CustomManager>();
            
            services.AddScoped<ICustomService2, CustomManager2>();

        }

    }
}
