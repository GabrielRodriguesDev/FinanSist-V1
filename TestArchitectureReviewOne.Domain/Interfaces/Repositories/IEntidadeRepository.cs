using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestArchitectureReviewOne.Domain.Interfaces.Repositories
{
    public interface IEntidadeRepository
    {
        bool ExistePorNome(string nome);
    }
}