using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands.Autentica;
using FinanSist.Domain.Commands.Usuario;

namespace FinanSist.Domain.Interfaces.Services
{
    public interface IAutenticaService
    {
        LoginCommandResult Login(LoginCommand cmd);
        GenericCommandResult EsqueceuSenha(EsqueceuSenhaCommand cmd);

        GenericCommandResult AlterarSenha(AlterarSenhaCommand cmd);
    }
}