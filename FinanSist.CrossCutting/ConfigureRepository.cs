using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FinanSist.Database;
using FinanSist.Database.Repositories;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Interfaces.Helpers;
using FinanSist.Database.Helpers;

namespace FinanSist.CrossCutting;
public class ConfigureRepository
{
    public static void Config(IServiceCollection services)
    {
        //var connectionString = "Server=localhost;Port=7000;Database=FinanSist;Uid=root;Pwd=fx870"; //Migration Container
        //var connectionString = "Server=172.18.0.2;Port=3306;Database=FinanSist;Uid=root;Pwd=fx870"; //Container
        var connectionString = "Server=localhost;Port=3306;Database=FinanSist;Uid=root;Pwd=fx870"; //Container

        services.AddDbContext<FinanSistContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        services.AddScoped<FinanSistContext, FinanSistContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IEntidadeRepository, EntidadeRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IDespesaRepository, DespesaRepository>();
        services.AddScoped<IDespesaTagRepository, DespesaTagRepository>();

        services.AddScoped<ISequenciaHelper, SequenciaHelper>();
    }
}
