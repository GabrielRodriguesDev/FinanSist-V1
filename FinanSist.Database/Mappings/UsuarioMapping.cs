using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinanSist.Domain.Entities;

namespace FinanSist.Database.Mappings
{
    public class UsuarioMapping : BaseMapping<Usuario>, IMapping
    {
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            entity.Property(a => a.Nome).HasColumnType("varchar(120)").IsRequired();
            entity.Property(a => a.Telefone).HasColumnType("varchar(30)");
            entity.Property(a => a.Email).HasColumnType("varchar(100)").IsRequired();
            entity.HasIndex(a => a.Email).HasDatabaseName("UnqUsuarioEmail").IsUnique();
            entity.Property(a => a.Senha).HasColumnType("LONGTEXT");
            entity.Property(a => a.Permissao).HasColumnType("varchar(20)").IsRequired();


            #region Comentários
            entity.HasComment("Tabela reposável por organizar os usuários");
            entity.Property(b => b.Nome).HasComment("Nome do usuário");
            entity.Property(b => b.Telefone).HasComment("Telefone do usuário");
            entity.Property(b => b.Email).HasComment("E-mail do usuário");
            entity.Property(b => b.Senha).HasComment("Senha do usuário");
            entity.Property(b => b.Permissao).HasComment("Permissão do usuário, sendo elas: Administrador e Padrao");
            #endregion
        }

    }
}