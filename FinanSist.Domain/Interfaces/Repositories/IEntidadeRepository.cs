using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Entities;

namespace FinanSist.Domain.Interfaces.Repositories
{
    public interface IEntidadeRepository : IBaseRepository<Entidade>
    {
        bool ExistePorNome(string nome);
    }
}