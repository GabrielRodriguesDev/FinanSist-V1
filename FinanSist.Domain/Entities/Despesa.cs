using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands.Despesa;
using FinanSist.Domain.Helpers;

namespace FinanSist.Domain.Entities
{
    public class Despesa : BaseEntity
    {

        #region Property
        public String? Descricao { get; private set; } = null!;
        public DateTime? DataPagamento { get; private set; }
        public DateTime? DataPrevisao { get; private set; }
        public Guid? EntidadeId { get; private set; }
        public Entidade? Entidade { get; private set; }
        public Guid? CategoriaId { get; private set; }
        public Categoria? Categoria { get; private set; }
        public Guid? TagId { get; private set; }
        public Tag? Tag { get; private set; }
        public String? Observacao { get; private set; }
        public int CodigoInterno { get; private set; }
        #endregion

        #region Constructor
        public Despesa() { }
        public Despesa(CreateDespesaCommand cmd)
        {
            this.Descricao = cmd.Descricao;
            this.DataPagamento = cmd.DataPagamento;
            this.DataPrevisao = cmd.DataPrevisao;
            this.EntidadeId = cmd.EntidadeId;
            this.CategoriaId = cmd.CategoriaId;
            this.TagId = cmd.TagId;
            this.Observacao = cmd.Observacao;
        }

        public void Update(UpdateDespesaCommand cmd)
        {
            this.Descricao = cmd.Descricao;
            this.DataPagamento = cmd.DataPagamento;
            this.DataPrevisao = cmd.DataPrevisao;
            this.EntidadeId = cmd.EntidadeId;
            this.CategoriaId = ValidationHelper.validateGuid(this.CategoriaId, cmd.CategoriaId);
            this.TagId = ValidationHelper.validateGuid(this.TagId, cmd.TagId);
            this.Observacao = cmd.Observacao;
        }
        #endregion

        #region Method
        public void setCodigoInterno(int value)
        {
            this.CodigoInterno = value;
        }
        #endregion

    }
}