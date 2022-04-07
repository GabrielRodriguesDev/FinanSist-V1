using FinanSist.Domain.Commands;
using FinanSist.Domain.Commands.Entidade;

namespace FinanSist.Domain.Interfaces.Services
{
    public interface IEntidadeService
    {
        GenericCommandResult Create(CreateEntidadeCommand createEntidadeCommand);
        GenericCommandResult Update(UpdateEntidadeCommand updateEntidadeCommand);

        GenericCommandResult Delete(Guid Id);
    }
}