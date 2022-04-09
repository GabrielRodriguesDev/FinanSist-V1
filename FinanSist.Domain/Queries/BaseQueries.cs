using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanSist.Domain.Queries.Params;

namespace FinanSist.Domain.Queries
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

        public static string Pesquisar(SearchParams searchParams)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select ");
            if (searchParams.CamposTabela != null && searchParams.CamposTabela.Count() > 0)
            {
                sql.Append(String.Join(",", searchParams.CamposTabela));
            }
            else
            {
                sql.Append("* ");
            }
            sql.AppendLine($" From {searchParams.NomeTabela} Where 1=1");

            if (searchParams.Ativo != null)
            {
                sql.AppendLine($@"and Ativo = @Ativo");
            }
            if (!String.IsNullOrEmpty(searchParams.Texto))
            {
                if (searchParams.TextosFiltroTabela != null && searchParams.TextosFiltroTabela.Count() > 0)
                {
                    StringBuilder filtro = new StringBuilder();
                    foreach (var item in searchParams.TextosFiltroTabela)
                    {
                        if (filtro.Length > 0)
                        {
                            filtro.Append(" or ");
                        }
                        filtro.AppendLine($"{item} LIKE CONCAT('%', @Texto, '%')");
                    }
                    sql.AppendLine($" and {filtro.ToString()}");
                }
            }
            return sql.ToString();
        }
    }
}