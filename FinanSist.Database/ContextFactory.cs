using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinanSist.Database
{
    public class ContextFactory : IDesignTimeDbContextFactory<FinanSistContext>
    {
        public FinanSistContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=3306;Database=FinanSist;Uid=root;Pwd=fx870";

            var optionsBuilder = new DbContextOptionsBuilder<FinanSistContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new FinanSistContext(optionsBuilder.Options);

        }
    }
}