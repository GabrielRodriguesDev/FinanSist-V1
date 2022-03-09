using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestArchitectureReviewOne.Domain.Commands.Usuario;

namespace TestArchitectureReviewOne.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        GenericCommandResult Create(CreateUsuarioCommand createCommand);

        GenericCommandResult Update(UpdateUsuarioCommand updateCommand);
        GenericCommandResult Delete(Guid id);
    }
}