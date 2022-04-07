using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanSist.Domain.Queries.Result.Despesa
{
    public class DespesaFormQueryResult
    {
        public Guid Id { get; set; }
        public String Descricao { get; set; } = null!;
        public DateTime? DataPagamento { get; set; }
        public DateTime? DataPrevisao { get; set; }
        public Guid EntidadeId { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid TagId { get; set; }
        public String Observacao { get; set; } = null!;
    }
}