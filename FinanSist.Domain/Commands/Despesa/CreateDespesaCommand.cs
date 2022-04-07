using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Interfaces.Commands;
using FinanSist.Domain.Notifications;

namespace FinanSist.Domain.Commands.Despesa
{
    public class CreateDespesaCommand : Notificable, ICommand
    {
        public String Descricao { get; set; } = null!;
        public DateTime? DataPagamento { get; set; }
        public DateTime? DataPrevisao { get; set; }
        public Guid? EntidadeId { get; set; }
        public Guid? CategoriaId { get; set; }
        public Guid? TagId { get; set; }
        public String? Observacao { get; set; } = null!;
        public override void Validate()
        {
            if (this.Descricao != null)
            {
                if (this.Descricao.Length > 200) this.AddNotification("Descricao", "Descricao deve conter no máximo 200 caracteres.");
            }

            if (EntidadeId == null)
            {
                this.AddNotification("EntidadeId", "Informe a Entidade.");
            }
            if (this.Observacao != null)
            {
                if (this.Observacao.Length > 200) this.AddNotification("Observacao", "Observacao deve conter no máximo 200 caracteres.");
            }
        }
    }
}