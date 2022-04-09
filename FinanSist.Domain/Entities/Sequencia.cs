using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanSist.Domain.Entities
{
    public class Sequencia : BaseEntity
    {
        #region Property
        public String Nome { get; private set; } = null!;
        public int Numero { get; private set; }
        #endregion

        #region Constructor
        public Sequencia(String nome)
        {
            this.Nome = nome.ToUpper();
            this.Numero = 1;
        }
        public Sequencia()
        {
        }
        #endregion

        #region  Method
        public int ProximoNumero()
        {
            this.Numero += 1;
            return Numero;
        }
        #endregion
    }
}