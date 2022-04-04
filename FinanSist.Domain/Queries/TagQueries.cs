using System.Reflection;
using FinanSist.Domain.Attributes;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries.Result.Tag;

namespace FinanSist.Domain.Queries
{
    public class TagQueries
    {
        public static ExtracaoCamposParams ExtrairCamposForm()
        {
            var type = typeof(TagFormQueryResult);
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
            var type = typeof(ListaTagQueryResult);
            PropertyInfo[] properties = type.GetProperties();
            string[] camposTabela = properties.Select(campo =>
            {
                var value = campo.GetCustomAttributes().Select(atributoCustomizado => atributoCustomizado is IgnoreProperty).FirstOrDefault();

                if (!value)
                {
                    return campo.Name;
                }
                return "";
            }).Where(campoName => !String.IsNullOrEmpty(campoName)).ToArray();

            string[] textosFiltro = properties.Select(campo =>
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
                TextosFiltro = textosFiltro
            };
        }

        public static String ExistePorNome()
        {
            return @"Select * from Tag Where Nome = @Nome";
        }
    }
}