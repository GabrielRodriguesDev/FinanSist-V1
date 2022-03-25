using FinanSist.Domain.Interfaces.Commands;
using FinanSist.Domain.Notifications;

namespace FinanSist.Domain.Commands.Email
{
    public class MensagemEmailCommand : Notificable, ICommand
    {
        public MensagemEmailCommand()
        {
            Destinatarios = new List<string>();
        }
        public string Assunto { get; set; } = null!;
        public string Corpo { get; set; } = null!;
        public List<string> Destinatarios { get; set; } = null!;
        public bool Html { get; set; }
        public string De { get; set; } = null!;
        public string EmailDe { get; set; } = null!;
        public string ResponderPara { get; set; } = null!;

        public override void Validate()
        {

        }
    }
}