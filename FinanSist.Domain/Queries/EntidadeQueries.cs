using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FinanSist.Domain.Attributes;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries.Result.Entidade;

namespace FinanSist.Domain.Queries
{
    public class EntidadeQueries
    {
        public static ExtracaoCamposParams ExtrairCamposForm()
        {
            var type = typeof(EntidadeFormQueryResult);
            PropertyInfo[] properties = type.GetProperties();
            String[] camposTabela = properties.Select(campo =>
            {
                var value = campo.GetCustomAttributes().Select(atributoCustomizado => atributoCustomizado is IgnoreProperty).FirstOrDefault();

                if (!value)
                {
                    return campo.Name;
                }
                return "";
            }).Where(campoNome => !String.IsNullOrEmpty(campoNome)).ToArray();

            return new ExtracaoCamposParams
            {
                CamposTabela = camposTabela
            };
        }

        public static ExtracaoCamposParams ExtrairCamposLista()
        {
            var type = typeof(ListaEntidadeQueryResult);
            PropertyInfo[] properties = type.GetProperties();
            String[] camposTabela = properties.Select(campo =>
            {
                var value = campo.GetCustomAttributes().Select(atributoCustomizado => atributoCustomizado is IgnoreProperty).FirstOrDefault();

                if (!value)
                {
                    return campo.Name;
                }
                return "";
            }).Where(campoNome => !String.IsNullOrEmpty(campoNome)).ToArray();

            String[] textosFiltros = properties.Select(campo =>
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

        public static string ExistePorNome()
        {
            return @"Select * from Entidade Where Nome = @Nome";
        }
    }
}