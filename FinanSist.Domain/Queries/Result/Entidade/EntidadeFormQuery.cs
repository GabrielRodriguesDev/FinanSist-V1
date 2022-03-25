using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanSist.Domain.Queries.Result.Entidade
{
    public class EntidadeFormQuery
    {
        public Guid Id { get; set; }
        public String Nome { get; set; } = null!;
        public String Descricao { get; set; } = null!;

    }
}