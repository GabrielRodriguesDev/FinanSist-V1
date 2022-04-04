using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Attributes;

namespace FinanSist.Domain.Queries.Result.Categoria
{
    public class ListaCategoriaQueryResult
    {
        public Guid Id { get; set; }
        [Search]
        public String Nome { get; set; } = null!;
        [Search]
        public int Tipo { get; set; }
        public bool Ativo { get; set; }
    }
}