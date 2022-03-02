using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TestArchitectureReviewOne.Database
{
    public class ContextFactory : IDesignTimeDbContextFactory<TestArchitectureReviewOneContext>
    {
        public TestArchitectureReviewOneContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=3306;Database=TestArchitectureReviewOne;Uid=root;Pwd=fx870";

            var optionsBuilder = new DbContextOptionsBuilder<TestArchitectureReviewOneContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new TestArchitectureReviewOneContext(optionsBuilder.Options);

        }
    }
}