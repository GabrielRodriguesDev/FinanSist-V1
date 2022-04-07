using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    }
}