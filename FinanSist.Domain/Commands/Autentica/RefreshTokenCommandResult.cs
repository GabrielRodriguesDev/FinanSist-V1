using System;
using System.Text.Json.Serialization;

namespace FinanSist.Domain.Commands.Autentica
{
    public class RefreshTokenCommandResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

        [JsonIgnore]
        public Autenticado Autenticado { get; set; } = null!;

        public RefreshTokenCommandResult(bool sucess, string menssage)
        {
            this.Success = sucess;
            this.Message = menssage;
        }

        public RefreshTokenCommandResult(bool sucess, string menssage, object? data)
        {
            this.Success = sucess;
            this.Message = menssage;
            this.Data = data;
        }

        public RefreshTokenCommandResult(bool sucess, string menssage, Autenticado autenticado)
        {
            this.Success = sucess;
            this.Message = menssage;
            this.Autenticado = autenticado;
        }

    }

    public class RefreshAutenticado
    {
        #region  Property
        public bool Success { get; set; }
        public string? Mensagem { get; set; }
        public Guid? UsuarioId { get; set; }
        public string? RefreshToken { get; set; }
        public object? Data { get; set; }


        #endregion

        #region  Constructor
        public RefreshAutenticado(bool sucess, string mensage, object? data)
        {
            this.Success = sucess;
            this.Mensagem = Mensagem;
            this.Data = data;
        }

        public RefreshAutenticado(bool sucess, string mensage)
        {
            this.Success = sucess;
            this.Mensagem = mensage;
        }

        public RefreshAutenticado(bool sucess, string mensagem, Guid usuarioId, string refreshToken)
        {
            this.Success = sucess;
            this.Mensagem = mensagem;
            this.UsuarioId = usuarioId;
            this.RefreshToken = refreshToken;
        }
        #endregion
    }
}