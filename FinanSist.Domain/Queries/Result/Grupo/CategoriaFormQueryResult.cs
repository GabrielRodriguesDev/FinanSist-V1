using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanSist.Domain.Queries.Result
{
    public class CategoriaFormQueryResult
    {

        public Guid Id { get; set; }
        public String Nome { get; set; } = null!;

        public int Tipo { get; set; }
    }
}