using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands;
using FinanSist.Domain.Commands.DespesaTag;
using FinanSist.Domain.Entities;

namespace FinanSist.Domain.Interfaces.Services
{
    public interface IDespesaTagService
    {
        GenericCommandResult Create(GenericDepesaTagCommand createDepesaTagCommand);

        bool Delete(Guid despesaId);
    }
}