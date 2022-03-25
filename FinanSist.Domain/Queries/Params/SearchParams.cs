using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanSist.Domain.Queries.Params
{
    public class SearchParams
    {

        [JsonIgnore]
        public string? NomeTabela { get; set; }
        [JsonIgnore]
        public string[]? CamposTabela { get; set; }

        [JsonIgnore]
        public string[]? TextosFiltroTabela { get; set; }

        public string? Texto { get; set; } = null!;

        public bool? Ativo { get; set; }

    }
}