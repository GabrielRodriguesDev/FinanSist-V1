using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Attributes;

namespace FinanSist.Domain.Queries.Result.Entidade
{
    public class ListaEntidadeQueryResult
    {
        public Guid Id { get; set; }
        [Search]
        public String Nome { get; set; } = null!;
        public String Descricao { get; set; } = null!;
    }
}