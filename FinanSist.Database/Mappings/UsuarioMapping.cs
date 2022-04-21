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
            base.OnModelCreating(modelBuilder); //Executando classe da base (BaseMapping).
            entity.Property(a => a.Nome).HasColumnType("varchar(120)").IsRequired();
            entity.Property(a => a.Telefone).HasColumnType("varchar(30)");
            entity.Property(a => a.Email).HasColumnType("varchar(100)").IsRequired();
            entity.HasIndex(a => a.Email).HasDatabaseName("UnqUsuarioEmail").IsUnique();
            entity.Property(a => a.Senha).HasColumnType("LONGTEXT");
            entity.Property(a => a.Permissao).HasColumnType("varchar(20)").IsRequired();
            entity.Property(a => a.RefreshToken).HasColumnType("varchar(50)");
            entity.HasIndex(a => a.TokenSenha).HasDatabaseName("UnqUsuarioTokenSenha").IsUnique();
            entity.HasIndex(a => a.RefreshToken).HasDatabaseName("UnqUsuarioRefreshToken").IsUnique();



            #region Comments
            entity.HasComment("Tabela reposável por organizar os usuários.");
            entity.Property(b => b.Nome).HasComment("Nome do usuário.");
            entity.Property(b => b.Telefone).HasComment("Telefone do usuário.");
            entity.Property(b => b.Email).HasComment("E-mail do usuário.");
            entity.Property(b => b.Senha).HasComment("Senha do usuário.");
            entity.Property(b => b.Permissao).HasComment("Permissão do usuário, sendo elas: Administrador e Padrao.");
            entity.Property(b => b.TokenSenha).HasComment("Token para alteração da senha.");
            entity.Property(b => b.TokenSenhaValidade).HasComment("Validade do token de alteração de senha.");
            entity.Property(b => b.RefreshToken).HasComment("Token para possibilitar o usuario a revalidar o token JWT de autenticação.");
            entity.Property(b => b.RefreshToken).HasComment("Validade do refresh token.");
            #endregion
        }

    }
}