using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands.Tag;
using FinanSist.Domain.Commands.Usuario;

namespace FinanSist.Domain.Interfaces.Services
{
    public interface ITagService
    {
        GenericCommandResult Create(CreateTagCommand createTagCommand);
        GenericCommandResult Update(UpdateTagCommand updateTagCommand);

        GenericCommandResult Delete(Guid id);
    }
}