using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands.Categorias;
using FinanSist.Domain.Helpers.Enums;

namespace FinanSist.Domain.Entities
{
    public class Categoria : BaseEntity
    {


        #region Property
        public String Nome { get; set; } = null!;

        public int? Tipo { get; set; }

        public bool Ativo { get; private set; }
        #endregion

        #region  Constructor
        public Categoria()
        {
        }
        public Categoria(CreateCategoriaCommand cmd)
        {
            this.Nome = cmd.Nome;
            this.Tipo = cmd.Tipo;
            this.Ativo = true;
        }

        public void Update(UpdateCategoriaCommand cmd)
        {
            this.Nome = cmd.Nome;
            this.Tipo = cmd.Tipo;
            this.Ativo = cmd.Ativo;
        }
        #endregion

        #region Method
        #endregion
    }
}