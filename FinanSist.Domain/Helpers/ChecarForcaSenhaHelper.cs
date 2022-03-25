using System.Text.RegularExpressions;

public static class ChecarForcaSenhaHelper
{
    public static int GeraPontosSenha(string senha)
    {
        if (senha == null) return 0;
        int pontosPorTamanho = GetPontoPorTamanho(senha);
        int pontosPorMinusculas = GetPontoPorMinusculas(senha);
        int pontosPorMaiusculas = GetPontoPorMaiusculas(senha);
        int pontosPorDigitos = GetPontoPorDigitos(senha);
        int pontosPorSimbolos = GetPontoPorSimbolos(senha);
        int pontosPorRepeticao = GetPontoPorRepeticao(senha);
        return pontosPorTamanho + pontosPorMinusculas + pontosPorMaiusculas + pontosPorDigitos + pontosPorSimbolos - pontosPorRepeticao;
    }

    private static int GetPontoPorTamanho(string senha)
    {
        return Math.Min(10, senha.Length) * 6;
    }

    private static int GetPontoPorMinusculas(string senha)
    {
        int rawplacar = senha.Length - Regex.Replace(senha, "[a-z]", "").Length;
        return Math.Min(2, rawplacar) * 5;
    }

    private static int GetPontoPorMaiusculas(string senha)
    {
        int rawplacar = senha.Length - Regex.Replace(senha, "[A-Z]", "").Length;
        return Math.Min(2, rawplacar) * 5;
    }

    private static int GetPontoPorDigitos(string senha)
    {
        int rawplacar = senha.Length - Regex.Replace(senha, "[0-9]", "").Length;
        return Math.Min(2, rawplacar) * 5;
    }

    private static int GetPontoPorSimbolos(string senha)
    {
        int rawplacar = Regex.Replace(senha, "[a-zA-Z0-9]", "").Length;
        return Math.Min(2, rawplacar) * 5;
    }

    private static int GetPontoPorRepeticao(string senha)
    {
        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(\w)*.*\1");
        bool repete = regex.IsMatch(senha);
        if (repete)
        {
            return 30;
        }
        else
        {
            return 0;
        }
    }

    public static bool SenhaValida(string senha)
    {
        int placar = GeraPontosSenha(senha);
        if (placar < 60) return false;
        return true;
    }
}