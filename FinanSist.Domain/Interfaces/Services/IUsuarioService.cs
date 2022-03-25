using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands.Usuario;

namespace FinanSist.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        GenericCommandResult Create(CreateUsuarioCommand createCommand);

        GenericCommandResult Update(UpdateUsuarioCommand updateCommand);
        GenericCommandResult Delete(Guid id);
    }
}