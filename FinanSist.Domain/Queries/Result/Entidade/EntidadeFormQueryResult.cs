using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanSist.Domain.Queries.Result.Entidade
{
    public class EntidadeFormQueryResult
    {
        public Guid Id { get; set; }
        public String Nome { get; set; } = null!;
        public String Descricao { get; set; } = null!;
        public bool Ativo { get; set; }

    }
}