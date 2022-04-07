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
        [IgnoreProperty]
        public String Descricao { get; set; } = null!;
        [Search]
        public DateTime DataPagamento { get; set; }
        [Search]
        public DateTime DataPrevisao { get; set; }
        public Guid EntidadeId { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid TagId { get; set; }
        [IgnoreProperty]
        public String Observacao { get; set; } = null!;
    }
}