using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FinanSist.Database;
using FinanSist.Database.Repositories;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;

namespace FinanSist.CrossCutting;
public class ConfigureRepository
{
    public static void Config(IServiceCollection services)
    {
        services.AddDbContext<FinanSistContext>(options => options.UseMySql("Server=localhost;Port=3306;Database=FinanSist;Uid=root;Pwd=fx870", ServerVersion.AutoDetect("Server=localhost;Port=3306;Database=FinanSist;Uid=root;Pwd=fx870")));
        services.AddScoped<FinanSistContext, FinanSistContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();

    }
}
