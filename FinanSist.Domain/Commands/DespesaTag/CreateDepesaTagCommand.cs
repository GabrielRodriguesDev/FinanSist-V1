using FinanSist.Domain.Interfaces.Commands;
using FinanSist.Domain.Notifications;

namespace FinanSist.Domain.Commands.DespesaTag
{
    public class GenericDepesaTagCommand : Notificable, ICommand
    {
        public Guid? DespesaId { get; set; }
        public Guid? TagId { get; set; }

        public GenericDepesaTagCommand()
        {

        }
        public GenericDepesaTagCommand(Guid despesaId, Guid tagId)
        {
            this.DespesaId = despesaId;
            this.TagId = tagId;
        }

        public override void Validate()
        {
            if (this.DespesaId == null)
            {
                this.AddNotification("EntidadeId", "Informe a Despesa.");
            }
            if (this.TagId == null)
            {
                this.AddNotification("TagId", "Informe a Tag.");
            }
        }
    }
}