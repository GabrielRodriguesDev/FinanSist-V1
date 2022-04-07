using FinanSist.Domain.Commands;
using FinanSist.Domain.Commands.Tag;

namespace FinanSist.Domain.Interfaces.Services
{
    public interface ITagService
    {
        GenericCommandResult Create(CreateTagCommand createTagCommand);
        GenericCommandResult Update(UpdateTagCommand updateTagCommand);

        GenericCommandResult Delete(Guid id);
    }
}