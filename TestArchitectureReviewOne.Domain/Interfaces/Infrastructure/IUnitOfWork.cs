using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TestArchitectureReviewOne.Domain.Interfaces.Infrastructure
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        IDbTransaction CurrentTransaction();
    }
}