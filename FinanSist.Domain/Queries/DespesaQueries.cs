using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FinanSist.Domain.Attributes;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries.Result.Despesa;

namespace FinanSist.Domain.Queries
{
    public class DespesaQueries
    {
        public static ExtracaoCamposParams ExtrairCamposForm()
        {
            var type = typeof(DespesaFormQueryResult);
            PropertyInfo[] properties = type.GetProperties();
            string[] camposTabela = properties.Select(campo =>
            {
                var value = campo.GetCustomAttributes().Select(atributoCustomizado => atributoCustomizado is IgnoreProperty).FirstOrDefault();

                if (!value)
                {
                    return campo.Name;
                }
                return "";
            }).Where(campoNome => !String.IsNullOrEmpty(campoNome)).ToArray();
            return new ExtracaoCamposParams()
            {
                CamposTabela = camposTabela
            };
        }

        public static ExtracaoCamposParams ExtrairCamposLista()
        {
            var type = typeof(ListaDespesaQueryResult);
            PropertyInfo[] properties = type.GetProperties();
            string[] camposTabela = properties.Select(campo =>
            {
                var value = campo.GetCustomAttributes().Select(atributoCustomizado => atributoCustomizado is IgnoreProperty).FirstOrDefault();
                if (!value)
                {
                    return campo.Name;
                }
                return "";
            }).Where(campoNome => !String.IsNullOrEmpty(campoNome)).ToArray();

            string[] textosFiltros = properties.Select(campo =>
            {
                var value = campo.GetCustomAttributes().Select(atributoCustomizado => atributoCustomizado is Search).FirstOrDefault();

                if (value)
                {
                    return campo.Name;
                }
                return "";
            }).Where(campoNome => !String.IsNullOrEmpty(campoNome)).ToArray();
            return new ExtracaoCamposParams()
            {
                CamposTabela = camposTabela,
                TextosFiltro = textosFiltros
            };
        }

        public static string Pesquisar(SearchParams searchParams)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select DP.");
            if (searchParams.CamposTabela != null && searchParams.CamposTabela.Count() > 0)
            {
                sql.Append(String.Join(", DP.", searchParams.CamposTabela));
                sql.Append(", ENT.Nome As Entidade, CT.Nome As Categoria ");
            }
            else
            {
                sql.Append("* ");
            };
            sql.AppendLine($" From {searchParams.NomeTabela} DP ");
            sql.AppendLine("Join Entidade ENT On ENT.Id = DP.EntidadeId ");
            sql.AppendLine("Left Join Categoria CT On CT.Id = DP.CategoriaId ");

            sql.AppendLine("Where 1=1");
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
                        filtro.AppendLine($"DP.{item} LIKE CONCAT('%', @Texto, '%')");
                    }
                    sql.AppendLine($" and {filtro.ToString()}");
                }
            }
            return sql.ToString();
        }
    }
}

