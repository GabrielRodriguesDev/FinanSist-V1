using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands.Entidade;
using FinanSist.Domain.Commands.Usuario;

namespace FinanSist.Domain.Interfaces.Services
{
    public interface IEntidadeService
    {
        GenericCommandResult Create(CreateEntidadeCommand createEntidadeCommand);
        GenericCommandResult Update(UpdateEntidadeCommand updateEntidadeCommand);

        GenericCommandResult Delete(Guid Id);
    }
}