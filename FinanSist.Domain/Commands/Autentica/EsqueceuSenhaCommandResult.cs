using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanSist.Domain.Commands.Autentica
{
    public class EsqueceuSenhaCommandResult
    {
        public Guid? Id { get; set; }
        public string Nome { get; private set; } = null!;
        public string Email { get; set; } = null!;

        public string? TokenSenha { get; private set; } = null!;

        public EsqueceuSenhaCommandResult(FinanSist.Domain.Entities.Usuario usuario)
        {
            this.Id = usuario.Id;
            this.Nome = usuario.Nome;
            this.Email = usuario.Email;
            this.TokenSenha = usuario.TokenSenha;
        }
    }
}