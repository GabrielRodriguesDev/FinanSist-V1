using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Helpers;
using FinanSist.Domain.Interfaces.Commands;
using FinanSist.Domain.Notifications;

namespace FinanSist.Domain.Commands.Autentica
{
    public class LoginCommand : Notificable, ICommand
    {
        #region Property
        public string Email { get; set; }
        public string Senha { get; set; }
        #endregion

        #region Constructor
        public LoginCommand()
        {
            this.Email = String.Empty;
            this.Senha = String.Empty;
        }

        #endregion

        #region Method
        public override void Validate()
        {
            if (String.IsNullOrEmpty(this.Email))
            {
                this.AddNotification("Email", "Informe o email");
            }
            else
            {
                if (this.Email.Length > 100)
                    this.AddNotification("Nome", "Nome deve conter no máximo 100 caracteres.");
                if (!ValidationHelper.IsValidEmail(this.Email))
                    this.AddNotification("Email", "Email digitado está inválido");
            }

            if (String.IsNullOrEmpty(this.Senha))
            {
                this.AddNotification("Senha", "Informe a senha");
            }
            else
            {
                if (Senha.Length < 6)
                    this.AddNotification("Senha", "Senha deve ter no mínimo 6 caracteres");
            }
        }
        #endregion
    }
}