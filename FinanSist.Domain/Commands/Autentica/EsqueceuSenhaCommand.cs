using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Helpers;
using FinanSist.Domain.Interfaces.Commands;
using FinanSist.Domain.Notifications;

namespace FinanSist.Domain.Commands.Autentica
{
    public class EsqueceuSenhaCommand : Notificable, ICommand
    {
        public string Email { get; set; }
        public EsqueceuSenhaCommand()
        {
            this.Email = String.Empty;
        }

        public override void Validate()
        {
            if (String.IsNullOrEmpty(Email))
                AddNotification("Email", "Informe o Email");

            if (!ValidationHelper.IsValidEmail(Email))
                AddNotification("Email", "Email digitado está inválido");
        }
    }
}