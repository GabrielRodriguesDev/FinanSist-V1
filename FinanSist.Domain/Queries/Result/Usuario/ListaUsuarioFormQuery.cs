using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Attributes;

namespace FinanSist.Domain.Queries.Result.Usuario
{
    public class ListaUsuarioFormQuery
    {
        public Guid Id { get; set; }
        [Search]
        public string Nome { get; set; } = null!;
        [Search]
        public string Email { get; set; } = null!;
        public bool Ativo { get; set; }
        public string Telefone { get; set; } = null!;
    }
}