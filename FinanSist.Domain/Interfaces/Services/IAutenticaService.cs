using FinanSist.Domain.Commands;
using FinanSist.Domain.Commands.Autentica;

namespace FinanSist.Domain.Interfaces.Services
{
    public interface IAutenticaService
    {
        LoginCommandResult Login(LoginCommand cmd, string refreshToken);
        GenericCommandResult EsqueceuSenha(EsqueceuSenhaCommand cmd);

        GenericCommandResult AlterarSenha(AlterarSenhaCommand cmd);

        RefreshTokenCommandResult RefreshToken(RefreshAutenticado cmd, string refreshToken);
    }
}