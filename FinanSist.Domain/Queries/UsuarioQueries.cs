using System.Reflection;
using FinanSist.Domain.Attributes;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries.Result;
using FinanSist.Domain.Queries.Result.Usuario;

namespace FinanSist.Domain.Queries
{
    public static class UsuarioQueries
    {
        public static string ExistePorEmail()
        {
            return "Select Id from Usuario where Email = @Email";
        }
        public static string PorEmail()
        {
            return @"Select * from Usuario Where Email = @Email";
        }

        public static string PorTokenSenha()
        {
            return @"Select * from Usuario Where TokenSenha = @TokenSenha";
        }
        public static ExtracaoCamposParams ExtrairCamporForm()
        {
            var type = typeof(UsuarioFormQueryResult); // Pegando a classe
            PropertyInfo[] properties = type.GetProperties(); // Pegando os atributos publicos da classe
            string[] camposTabela = properties.Select(campo => // Mapeando cada atributo da classe
            {
                var value = campo.GetCustomAttributes().Select(atributoCustomizado => atributoCustomizado is IgnoreProperty).FirstOrDefault(); // Verificando se algum possui a anotação IgnoreProperty
                if (!value)
                {
                    return campo.Name; // Se não tiver o anotação retorna o nome do atributo
                }
                return ""; // Caso tenha retorna "vazio"
            }).Where(campoNome => !string.IsNullOrEmpty(campoNome)).ToArray(); // Pegando o retorno sobre o mapeando anterior e realizando uma validação onde só retorna de fato oque não for null nem vazio

            return new ExtracaoCamposParams() // Instanciando a classe
            {
                CamposTabela = camposTabela // Atribuindo os campos mapeados para o atributo da classe
            };
        }

        public static ExtracaoCamposParams ExtrairCamposLista()
        {
            var type = typeof(ListaUsuarioFormQuery);
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

            return new ExtracaoCamposParams
            {
                CamposTabela = camposTabela,
                TextosFiltro = textosFiltros
            };
        }
    }
}