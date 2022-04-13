using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Interfaces.Commands;
using FinanSist.Domain.Notifications;

namespace FinanSist.Domain.Commands.Despesa
{
    public class UpdateDespesaCommand : Notificable, ICommand
    {
        public Guid? Id { get; set; }
        public String? Descricao { get; set; } = null!;
        public DateTime? DataPagamento { get; set; }
        public DateTime? DataPrevisao { get; set; }
        public Guid? EntidadeId { get; set; }
        public Guid? CategoriaId { get; set; }

        public String? Observacao { get; set; }

        public IEnumerable<Guid>? TagId { get; set; } = null!;

        public override void Validate()
        {
            if (this.Id == null)
            {
                this.AddNotification("Id", "Informe o Id.");
            }
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
            if (this.TagId != null && this.TagId.Count() > 0)
            {
                this.TagId = this.TagId.Distinct();
                if (this.TagId.Count() > 3)
                {
                    this.AddNotification("TagId", "Despesa só pode conter no máximo 3 Tags.");
                }
            }
        }
    }
}