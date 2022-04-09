using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Attributes;

namespace FinanSist.Domain.Queries.Result.Despesa
{
    public class ListaDespesaQueryResult
    {
        public Guid Id { get; set; }
        [Search]
        public String Descricao { get; set; } = null!;

        [Search]
        public DateTime? DataPagamento { get; set; }

        [Search]
        public DateTime? DataPrevisao { get; set; }

        [IgnoreProperty]
        public string Entidade { get; set; } = null!;

        [IgnoreProperty]
        public string Categoria { get; set; } = null!;

        [IgnoreProperty]
        public string Tag { get; set; } = null!;

        [IgnoreProperty]
        public String? Observacao { get; set; } = null!;
    }
}