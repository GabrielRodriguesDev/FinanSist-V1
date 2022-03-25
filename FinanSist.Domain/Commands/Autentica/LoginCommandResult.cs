using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanSist.Domain.Commands.Autentica
{
    public class LoginCommandResult
    {
        #region  Property
        public bool Success { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
        public Autenticado Autenticado { get; set; } = null!;

        #endregion

        #region  Constructor
        public LoginCommandResult(bool success, string message, Autenticado autenticado)
        {
            this.Success = success;
            this.Message = message;
            this.Autenticado = autenticado;
        }

        public LoginCommandResult(bool success, string message, object? data)
        {
            this.Success = success;
            this.Message = message;
            this.Data = data;
        }

        public LoginCommandResult(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }

        #endregion

    }
#nullable disable
    public class Autenticado
    {
        #region  Property
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Permissao { get; set; }
        #endregion

        #region  Constructor
        public Autenticado(FinanSist.Domain.Entities.Usuario usuario)
        {
            this.Id = usuario.Id;
            this.Nome = usuario.Nome;
            this.Email = usuario.Email;
            this.Permissao = usuario.Permissao;
        }
        #endregion
    }
}
