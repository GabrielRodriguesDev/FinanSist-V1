using System.Reflection;
using FinanSist.Domain.Attributes;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries.Result;
using FinanSist.Domain.Queries.Result.Grupo;

namespace FinanSist.Domain.Queries
{
    public class CategoriaQueries
    {

        public static string ExistePorNomeETipo()
        {
            return @"Select cat.Id from Categoria cat
                    Where
                    Nome = @Nome And
                    Tipo = @Tipo";
        }

        public static ExtracaoCamposParams ExtrairCamposForm()
        {
            var type = typeof(CategoriaFormQueryResult); // Pegando a classe
            PropertyInfo[] properties = type.GetProperties(); // Pegando os atributos publicos da classe
            string[] camposTabela = properties.Select(campo =>
            {
                var value = campo.GetCustomAttributes().Select(atributoCustomizado => atributoCustomizado is IgnoreProperty).FirstOrDefault(); // Verificando se algum possui a anotação IgnorePropertys
                if (!value)
                {
                    return campo.Name; // Se não tiver o anotação retorna o nome do atributo
                }
                return ""; // Caso tenha retorna "vazio"
            }).Where(campoNome => !String.IsNullOrEmpty(campoNome)).ToArray(); // Pegando o retorno sobre o mapeando anterior e realizando uma validação onde só retorna de fato oque não for null nem vazio

            return new ExtracaoCamposParams
            {
                CamposTabela = camposTabela
            };
        }


        public static ExtracaoCamposParams ExtrairCamposLista()
        {
            var type = typeof(ListaCategoriaQueryResult);
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
    }
}