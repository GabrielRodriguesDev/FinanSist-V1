using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands.Categorias;
using FinanSist.Domain.Commands.Usuario;

namespace FinanSist.Domain.Interfaces.Services
{
    public interface ICategoriaService
    {

        GenericCommandResult Create(CreateCategoriaCommand createCommand);
        GenericCommandResult Update(UpdateCategoriaCommand updateCommand);
        GenericCommandResult Delete(Guid id);
    }
}