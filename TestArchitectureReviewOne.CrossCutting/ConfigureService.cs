using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TestArchitectureReviewOne.Domain.Interfaces.Services;
using TestArchitectureReviewOne.Domain.Services;

namespace TestArchitectureReviewOne.CrossCutting
{
    public class ConfigureService
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}