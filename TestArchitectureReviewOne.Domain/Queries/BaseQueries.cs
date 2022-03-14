using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestArchitectureReviewOne.Domain.Queries.Params;

namespace TestArchitectureReviewOne.Domain.Queries
{
    public static class BaseQueries
    {
        public static string ExistePorId(string table)
        {
            return $"Select Id from {table} where Id = @Id";
        }

        public static string PesquisarForm(SearchFormParams searchFormParams)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select ");
            if (searchFormParams.CamposTabela != null && searchFormParams.CamposTabela.Count() > 0)
            {
                sql.Append(String.Join(",", searchFormParams.CamposTabela));
            }
            else
            {
                sql.Append("*");
            }
            sql.AppendLine($" From {searchFormParams.NomeTabela} Where 1=1");

            if (searchFormParams.Ativo != null)
            {
                sql.AppendLine($@" and Ativo = @Ativo");
            }
            sql.AppendLine($@" and Id = @Id");
            //sql.AppendLine(" )");
            return sql.ToString();

        }
    }
}