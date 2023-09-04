using Consultorio_Medico.BL;
using Consultorio_Medico.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.loC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDALDepencies(configuration);
            services.AddBLDependecies();
            return services;
        }

    }
}
