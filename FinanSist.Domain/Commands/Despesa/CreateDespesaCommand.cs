using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Helpers.Enums;
using FinanSist.Domain.Interfaces.Commands;
using FinanSist.Domain.Notifications;

namespace FinanSist.Domain.Commands.Despesa
{
    public class CreateDespesaCommand : Notificable, ICommand
    {
        public String Descricao { get; set; } = null!;
        public DateTime? DataPagamento { get; set; }
        public DateTime? DataPrevisao { get; set; }
        public DateTime? DataVencimento { get; set; }
        public decimal? Valor { get; set; }
        public bool Efetivado { get; set; }
        public Guid? EntidadeId { get; set; }
        public Guid? CategoriaId { get; set; }
        public String? Observacao { get; set; } = null!;
        public bool Repetir { get; set; }
        public int? QuantidadeRepeticao { get; set; }
        public int? PeriodoRepeticao { get; set; }
        public IEnumerable<Guid>? TagId { get; set; } = null!;
        public override void Validate()
        {
            if (this.Descricao != null)
            {
                if (this.Descricao.Length > 200) this.AddNotification("Descricao", "Descricao deve conter no máximo 200 caracteres.");
            }
            if (this.Valor <= 0)
            {
                this.AddNotification("Valor", "Valor da despesa deve ser maior que zero.");
            }
            if (EntidadeId == null)
            {
                this.AddNotification("EntidadeId", "Informe a Entidade.");
            }
            if (this.Observacao != null)
            {
                if (this.Observacao.Length > 200) this.AddNotification("Observacao", "Observacao deve conter no máximo 200 caracteres.");
            }
            if (this.TagId != null)
            {
                if (this.TagId.Count() > 0)
                {
                    this.TagId = this.TagId.Distinct();
                    if (this.TagId.Count() > 3)
                    {
                        this.AddNotification("TagId", "Despesa só pode conter no máximo 3 Tags.");
                    }
                }
            }

            if (this.Repetir == true)
            {
                if (this.QuantidadeRepeticao <= 0)
                {
                    this.AddNotification("QuantidadeRepeticao", "Quantidade de repetições deve ser maior que 0.");
                    if (this.QuantidadeRepeticao > 12)
                    {
                        this.AddNotification("QuantidadeRepeticao", "Só é possivel repetir uma mesma despesa até 12 vezes.");
                    }
                }

                bool result = false;
                foreach (var periodoRepeticao in Enum.GetValues(typeof(PeriodoRepeticaoEnum)))
                {
                    if (this.PeriodoRepeticao == (int)periodoRepeticao)
                    {
                        result = true;
                    }
                }
                if (result == false)
                {
                    this.AddNotification("PeriodoRepeticao", "Informe um período de repetição válido.");
                }
            }
            else
            {
                if (this.QuantidadeRepeticao != 0)
                {
                    this.AddNotification("QuantidadeRepeticao", "Quantidade de repetições deve ser igual a 0 para despesas que não se repetem.");
                }

                if (this.PeriodoRepeticao != 0)
                {
                    this.AddNotification("PeriodoRepeticao", "Período de repetição deve ser igual a 0 para despesas que não se repetem.");
                }
            }
        }

        public CreateDespesaCommand DeepCopy()
        {
            CreateDespesaCommand objectTemp = (CreateDespesaCommand)this.MemberwiseClone();
            objectTemp.Descricao = this.Descricao;
            objectTemp.DataPagamento = this.DataPagamento;
            objectTemp.DataPrevisao = this.DataPrevisao;
            objectTemp.DataVencimento = this.DataVencimento;
            objectTemp.Valor = this.Valor;
            objectTemp.Efetivado = this.Efetivado;
            objectTemp.EntidadeId = this.EntidadeId;
            objectTemp.CategoriaId = this.CategoriaId;
            objectTemp.Observacao = this.Observacao;
            objectTemp.Repetir = this.Repetir;
            objectTemp.QuantidadeRepeticao = this.QuantidadeRepeticao;
            objectTemp.PeriodoRepeticao = this.PeriodoRepeticao;
            return objectTemp;
        }
    }
}