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

        public int CodigoInterno { get; set; }

        public String Descricao { get; set; } = null!;
        [Search]
        public DateTime? DataDespesa { get; set; }

        public DateTime? DataPagamento { get; set; }

        public DateTime? DataPrevisao { get; set; }

        [Search]
        public DateTime? DataVencimento { get; set; }
        public decimal? Valor { get; set; }

        public bool Efetivado { get; set; }

        [IgnoreProperty]
        public string Entidade { get; set; } = null!;

        [IgnoreProperty]
        public string Categoria { get; set; } = null!;

        public String? DescricaoRepeticao { get; set; } = null!;

        public String? Observacao { get; set; } = null!;

    }
}