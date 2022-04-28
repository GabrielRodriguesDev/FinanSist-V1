using FinanSist.Domain.Commands;
using FinanSist.Domain.Commands.DespesaTag;

namespace FinanSist.Domain.Interfaces.Services
{
    public interface IDespesaTagService
    {
        GenericCommandResult Create(GenericDepesaTagCommand createDepesaTagCommand);



        bool Delete(Guid despesaId);
    }
}