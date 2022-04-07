using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Services;
using FinanSist.Domain.Services;
using FinanSist.Infra.Services;

namespace FinanSist.CrossCutting
{
    public class ConfigureService
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAutenticaService, AutenticaService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IEntidadeService, EntidadeService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IDespesaService, DespesaService>();

            services.AddScoped<IEmailService, EmailService>();
        }
    }
}