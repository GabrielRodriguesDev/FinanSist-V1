using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestArchitectureReviewOne.Database;
using TestArchitectureReviewOne.Database.Repositories;
using TestArchitectureReviewOne.Domain.Interfaces.Infrastructure;
using TestArchitectureReviewOne.Domain.Interfaces.Repositories;

namespace TestArchitectureReviewOne.CrossCutting;
public class ConfigureRepository
{
    public static void Config(IServiceCollection services)
    {
        services.AddDbContext<TestArchitectureReviewOneContext>(options => options.UseMySql("Server=localhost;Port=3306;Database=TestArchitectureReviewOne;Uid=root;Pwd=fx870", ServerVersion.AutoDetect("Server=localhost;Port=3306;Database=TestArchitectureReviewOne;Uid=root;Pwd=fx870")));
        services.AddScoped<TestArchitectureReviewOneContext, TestArchitectureReviewOneContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

    }
}
