using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanSist.Domain.Queries.Params
{
    public class SearchFormParams
    {
        public Guid Id { get; set; }
        public string? NomeTabela { get; set; }
        public string[]? CamposTabela { get; set; }
        public bool? Ativo { get; set; }
    }
}