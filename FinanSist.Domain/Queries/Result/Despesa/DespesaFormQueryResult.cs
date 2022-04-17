using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Attributes;

namespace FinanSist.Domain.Queries.Result.Despesa
{
    public class DespesaFormQueryResult
    {
        public Guid Id { get; set; }
        public String Descricao { get; set; } = null!;
        public DateTime? DataPagamento { get; set; }
        public DateTime? DataPrevisao { get; set; }
        public decimal Valor { get; set; }
        public bool Efetivado { get; set; }
        public Guid EntidadeId { get; set; }
        public Guid? CategoriaId { get; set; }
        [IgnoreProperty]
        public String Observacao { get; set; } = null!;
        [IgnoreProperty]
        public List<String> Tags { get; set; } = null!;

    }
}