using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinanSist.Domain.Entities;

namespace FinanSist.Database.Mappings
{
    public class EntidadeMapping : BaseMapping<Entidade>, IMapping
    {
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //Executando classe da base (BaseMapping).

            entity.Property(a => a.Nome).HasColumnType("varchar(120)").IsRequired();
            entity.Property(a => a.Descricao).HasColumnType("varchar(200)");
            entity.HasIndex(a => a.Nome).HasDatabaseName("UnqEntidadeNome").IsUnique();


            #region Comments
            entity.HasComment("Tabela reposável pelos registros das entidades");
            entity.Property(b => b.Nome).HasComment("Nome da entidade");
            entity.Property(b => b.Descricao).HasComment("Descrição da entidade");
            #endregion
        }
    }
}