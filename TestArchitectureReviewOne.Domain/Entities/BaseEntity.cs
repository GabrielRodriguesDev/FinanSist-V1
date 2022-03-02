using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestArchitectureReviewOne.Domain.Entities
{
    public class BaseEntity
    {

        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
            this.CriadoEm = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime? CriadoEm { get; private set; }

        public DateTime? AlteradoEm { get; private set; }

        public void setCriadoEm(DateTime time)
        {
            this.CriadoEm = time;
        }

        public void setAlteradoEm(DateTime time)
        {
            this.CriadoEm = time;
        }

        public void setId(Guid id)
        {
            this.Id = id;
        }
    }
}