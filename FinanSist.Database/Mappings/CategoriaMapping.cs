using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinanSist.Domain.Entities;

namespace FinanSist.Database.Mappings
{
    public class CategoriaMapping : BaseMapping<Categoria>, IMapping
    {
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            entity.Property(a => a.Nome).HasColumnType("varchar(120)").IsRequired();
            entity.Property(a => a.Tipo).HasColumnType("varchar(1)").IsRequired();

            #region Comentários
            entity.HasComment("Tabela reposável pelos registros das categorias");
            entity.Property(b => b.Nome).HasComment("Nome da categoria");
            entity.Property(b => b.Tipo).HasComment("Gerenciador de estado que define qual é o tipo da categoria, sendo eles: 0 [Receita] e 1 [Despesa]");
            #endregion
        }
    }
}