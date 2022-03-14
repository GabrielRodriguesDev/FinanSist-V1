using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestArchitectureReviewOne.Domain.Queries.Params
{
    public class ExtracaoCamposParams
    {
        public string[] CamposTabela { get; set; } = null!;
        public string[] TextosFiltro { get; set; } = null!;
    }
}