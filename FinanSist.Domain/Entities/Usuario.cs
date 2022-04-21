using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands.Usuario;
using FinanSist.Domain.Helpers;

namespace FinanSist.Domain.Entities
{
    public class Usuario : BaseEntity
    {

        #region Property
        public string Nome { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Telefone { get; private set; } = null!;
        public string? Senha { get; private set; } = null!;
        public string? TokenSenha { get; private set; } = null!;
        public DateTime? TokenSenhaValidade { get; private set; }
        public string? RefreshToken { get; private set; } = null!;
        public DateTime? RefreshTokenValidade { get; private set; }
        public bool Ativo { get; private set; }
        public bool ExigirNovaSenha { get; private set; }
        public string? Permissao { get; private set; } = null!;
        #endregion

        #region Constructor

        public Usuario()
        {

        }
        public Usuario(CreateUsuarioCommand cmd)
        {
            this.Nome = cmd.Nome;
            this.Email = cmd.Email;
            this.Telefone = cmd.Telefone;
            this.Senha = CriptoHelper.HashPassword(cmd.Senha);
            this.Ativo = true;
            this.ExigirNovaSenha = false;
            this.SetDefaultPemissao();
        }

        public void Update(UpdateUsuarioCommand cmd)
        {
            this.Nome = cmd.Nome;
            this.Email = cmd.Email;
            this.Telefone = cmd.Telefone;
            this.Ativo = cmd.Ativo;
            this.Permissao = this.AlteraPermissao(cmd.Permissao);
        }

        #endregion

        #region Method

        public bool VerificarSenha(string senhaDigitada)
        {
            if (Senha != null)
                return CriptoHelper.VerifyHashedPassword(Senha, senhaDigitada);
            else
                return false;
        }

        public void NovoTokenSenha()
        {
            this.TokenSenha = Guid.NewGuid().ToString();
            this.TokenSenhaValidade = DateTime.Now.AddMinutes(30);
        }

        public void NovoRefreshToken(string token)
        {
            this.RefreshToken = token;
            this.RefreshTokenValidade = DateTime.Now.AddMinutes(140);
        }


        public void AlterarSenha(string novaSenha)
        {
            this.Senha = CriptoHelper.HashPassword(novaSenha);
            this.TokenSenha = null;
            this.TokenSenhaValidade = null;
        }

        public void SetDefaultPemissao()
        {
            this.Permissao = "Padrao";
        }

        public string AlteraPermissao(string? permissao)
        {
            if (String.IsNullOrEmpty(permissao))
            {
                return this!.Permissao!;
            }
            return permissao;
        }
        #endregion
    }
}
