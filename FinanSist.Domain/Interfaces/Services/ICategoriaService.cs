using FinanSist.Domain.Commands;
using FinanSist.Domain.Commands.Categorias;

namespace FinanSist.Domain.Interfaces.Services
{
    public interface ICategoriaService
    {

        GenericCommandResult Create(CreateCategoriaCommand createCommand);
        GenericCommandResult Update(UpdateCategoriaCommand updateCommand);
        GenericCommandResult Delete(Guid id);
    }
}