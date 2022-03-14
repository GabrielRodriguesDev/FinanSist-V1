using System.Reflection;
using TestArchitectureReviewOne.Domain.Attributes;
using TestArchitectureReviewOne.Domain.Queries.Params;
using TestArchitectureReviewOne.Domain.Queries.Result;

namespace TestArchitectureReviewOne.Domain.Queries
{
    public static class UsuarioQueries
    {
        public static string ExistePorEmail()
        {
            return "Select Id from Usuario where Email = @Email";
        }


        public static ExtracaoCamposParams ExtrairCamporForm()
        {
            var type = typeof(UsuarioFormQueryResult); // Pegando a classe
            PropertyInfo[] properties = type.GetProperties(); // Pegando os atributos publicos da classe
            string[] camposTabela = properties.Select(campo => // Mapeando cada atributo da classe
            {
                var value = campo.GetCustomAttributes().Select(attribute => attribute is IgnoreProperty).FirstOrDefault(); // Verificando se algum possui a anotação IgnoreProperty

                if (!value)
                {
                    return campo.Name; // Se não tiver o anotação retorna o nome do atributo
                }
                return ""; // Caso tenha retorna "vazio"
            }).Where(campoName => !string.IsNullOrEmpty(campoName)).ToArray(); // Pegando o retorno sobre o mapeando anterior e realizando uma validação onde só retorna de fato oque não for null nem vazio

            return new ExtracaoCamposParams() // Instanciando a classe
            {
                CamposTabela = camposTabela // Atribuindo os campos mapeados para o atributo da classe
            };
        }
    }
}