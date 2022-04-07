using FinanSist.Domain.Commands;
using FinanSist.Domain.Commands.Autentica;

namespace FinanSist.Domain.Interfaces.Services
{
    public interface IAutenticaService
    {
        LoginCommandResult Login(LoginCommand cmd);
        GenericCommandResult EsqueceuSenha(EsqueceuSenhaCommand cmd);

        GenericCommandResult AlterarSenha(AlterarSenhaCommand cmd);
    }
}