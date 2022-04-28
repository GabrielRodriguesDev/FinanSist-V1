using FinanSist.Domain.Commands;
using FinanSist.Domain.Commands.Despesa;

namespace FinanSist.Domain.Interfaces.Services
{
    public interface IDespesaService
    {
        GenericCommandResult Create(CreateDespesaCommand createDespesaCommand);

        GenericCommandResult CreateDepesasRepeticao(CreateDespesaCommand createDespesaCommand);

        GenericCommandResult Update(UpdateDespesaCommand updateDespesaCommand);

        GenericCommandResult Delete(Guid id);
    }
}