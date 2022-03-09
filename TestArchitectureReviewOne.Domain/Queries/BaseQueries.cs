using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestArchitectureReviewOne.Domain.Queries
{
    public static class BaseQueries
    {
        public static string ExistePorId(string table)
        {
            return $"Select Id from {table} where Id = @Id";
        }
    }
}