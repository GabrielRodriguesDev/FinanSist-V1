using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Interfaces.Commands;
using FinanSist.Domain.Notifications;

namespace FinanSist.Domain.Commands.Autentica
{
    public class AlterarSenhaCommand : Notificable, ICommand
    {
        public string NovaSenha { get; set; } = null!;

        public string Token { get; set; } = null!;


        public override void Validate()
        {
            if (string.IsNullOrEmpty(this.NovaSenha))
            {
                this.AddNotification("Nova senha", "Informe a senha");
            }
            else
            {
                if (this.NovaSenha.Length < 6)
                {
                    this.AddNotification("Nova senha", "Senha deve conter no mínimo 6 caracteres");
                }
                if (!ChecarForcaSenhaHelper.SenhaValida(this.NovaSenha))
                {
                    this.AddNotification("Nova senha", "Desculpe, essa senha não pode ser cadastrada. (Nível Fraco)");
                }
            }

            if (String.IsNullOrEmpty(this.Token))
            {
                this.AddNotification("Token", "Informe o token de autorização");
            }
        }
    }
}