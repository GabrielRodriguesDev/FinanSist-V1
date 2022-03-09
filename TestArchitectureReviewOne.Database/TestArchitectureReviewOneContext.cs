using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TestArchitectureReviewOne.Database.Mappings;
using TestArchitectureReviewOne.Domain.Entities;

namespace TestArchitectureReviewOne.Database
{
    public class TestArchitectureReviewOneContext : DbContext
    {
#nullable disable
        public TestArchitectureReviewOneContext(DbContextOptions<TestArchitectureReviewOneContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Fazendo o mapeamento com o banco de dados
            //Pega todas as classes que estão implementando a interface IMapping
            //Assim o Entity Framework é capaz de carregar os mapeamentos
            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                  where x.IsClass && typeof(IMapping).IsAssignableFrom(x)
                                  select x).ToList();
            // Varrendo todos os tipos que são mapeamento 
            // Com ajuda do Reflection criamos as instancias 
            // e adicionamos no Entity Framework
            foreach (var mapping in typesToMapping)
            {
                IMapping mappingClass = Activator.CreateInstance(mapping) as IMapping;
                if (mappingClass != null)
                    mappingClass.OnModelCreating(modelBuilder);
            }
        }


        public DbSet<Usuario> Usuarios { get; set; }
    }
}