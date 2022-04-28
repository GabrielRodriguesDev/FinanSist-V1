using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands.Despesa;


namespace FinanSist.Domain.Entities
{
    public class Despesa : BaseEntity
    {

        #region Property
        public String? Descricao { get; private set; } = null!;
        public DateTime? DataDespesa { get; private set; }
        public DateTime? DataPagamento { get; private set; }
        public DateTime? DataPrevisao { get; private set; }
        public DateTime? DataVencimento { get; private set; }
        public decimal? Valor { get; private set; }
        public bool Efetivado { get; private set; }
        public Guid? EntidadeId { get; private set; }
        public Entidade? Entidade { get; private set; }
        public Guid? CategoriaId { get; private set; }
        public Categoria? Categoria { get; private set; }
        public String? Observacao { get; private set; }
        public bool Repetir { get; private set; }
        public int? QuantidadeRepeticao { get; private set; }
        public int? PeriodoRepeticao { get; private set; }
        public String? DescricaoRepeticao { get; private set; } = null!;
        public int CodigoInterno { get; private set; }
        public IList<DespesaTag>? DespesaTag { get; private set; }

        #endregion

        #region Constructor
        public Despesa() { }
        public Despesa(CreateDespesaCommand cmd)
        {
            this.Descricao = cmd.Descricao;
            this.DataDespesa = DateTime.Now;
            this.DataPagamento = cmd.DataPagamento;
            this.DataPrevisao = cmd.DataPrevisao;
            this.DataVencimento = cmd.DataVencimento;
            this.EntidadeId = cmd.EntidadeId;
            this.Valor = cmd.Valor;
            this.Efetivado = cmd.Efetivado;
            this.CategoriaId = cmd.CategoriaId;
            this.Observacao = cmd.Observacao;
            this.Repetir = cmd.Repetir;
            this.QuantidadeRepeticao = cmd.QuantidadeRepeticao;
            this.PeriodoRepeticao = cmd.PeriodoRepeticao;
        }

        public void Update(UpdateDespesaCommand cmd)
        {
            this.Descricao = cmd.Descricao;
            this.DataPagamento = cmd.DataPagamento;
            this.DataPrevisao = cmd.DataPrevisao;
            this.DataVencimento = cmd.DataVencimento;
            this.Valor = cmd.Valor;
            this.Efetivado = cmd.Efetivado;
            this.EntidadeId = cmd.EntidadeId;
            this.CategoriaId = cmd.CategoriaId;
            this.Observacao = cmd.Observacao;
        }
        #endregion

        #region Method
        public void setCodigoInterno(int value)
        {
            this.CodigoInterno = value;
        }

        public DateTime setDataDespesa(int periodoRepeticao)
        {
            switch (periodoRepeticao)
            {
                case 1:
                    return DateTime.Now.AddMonths(1);
                case 2:
                    return DateTime.Now.AddYears(1);
                default:
                    return DateTime.Now;
            }
        }

        public void setDataDespesaRepeticao(int controlador)
        {
            this.DataDespesa = this.DataDespesa!.Value.AddMonths(controlador);
            if (DataVencimento != null)
            {
                this.DataVencimento = this.DataVencimento!.Value.AddMonths(controlador);
            }
            this.DataPrevisao = null;
        }

        public void setDescricaoRepeticao(int repeticaoAtual)
        {
            this.DescricaoRepeticao = this.Descricao + ' ' + '(' + repeticaoAtual + '/' + this.QuantidadeRepeticao + ')';
        }
        #endregion

    }
}