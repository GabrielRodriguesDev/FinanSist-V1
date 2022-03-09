using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestArchitectureReviewOne.Domain.Entities;

namespace TestArchitectureReviewOne.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        bool ExistePorEmail(string email);

    }
}