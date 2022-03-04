using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestArchitectureReviewOne.Domain.Queries
{
    public static class EntidadeQueries
    {
        public static string ExistePorNome()
        {
            return "Select Nome from Entidade where Nome = @Nome";
        }
    }
}