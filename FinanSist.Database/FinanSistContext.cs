using System.Reflection;
using Microsoft.EntityFrameworkCore;
using FinanSist.Database.Mappings;
using FinanSist.Domain.Commands.Usuario;
using FinanSist.Domain.Entities;

namespace FinanSist.Database
{
    public class FinanSistContext : DbContext
    {
#nullable disable

        #region Property
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Entidade> Entidades { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Despesa> Despesas { get; set; }
        #endregion

        #region Constructor
        public FinanSistContext(DbContextOptions<FinanSistContext> options) : base(options)
        {

        }
        #endregion

        #region  Method
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
        #endregion
    }
}