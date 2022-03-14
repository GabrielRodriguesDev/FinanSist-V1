using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestArchitectureReviewOne.Domain.Queries.Result
{
    public class UsuarioFormQueryResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Ativo { get; set; }
        public string Telefone { get; set; } = null!;
    }
}