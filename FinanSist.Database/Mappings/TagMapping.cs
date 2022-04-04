using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanSist.Database.Mappings
{
    public class TagMapping : BaseMapping<Tag>, IMapping
    {
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //Executando classe da base (BaseMapping).
            entity.Property(a => a.Nome).HasColumnType("varchar(120)").IsRequired();
            entity.HasIndex(a => a.Nome).HasDatabaseName("UndTagNome").IsUnique();
            entity.Property(a => a.Descricao).HasColumnType("varchar(200)");


            #region Comments
            entity.Property(b => b.Nome).HasComment("Nome da Tag");
            entity.Property(b => b.Descricao).HasComment("Descrição da Tag");
            #endregion
        }
    }
}