using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FinanSist.Domain.Interfaces.Commands;
using FinanSist.Domain.Notifications;

namespace FinanSist.Domain.Commands.Autentica
{
    public class RefreshTokenCommand : Notificable, ICommand
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }

        [JsonIgnore]
        public string? tokeValidado { get; set; }
        public override void Validate()
        {
            if (String.IsNullOrEmpty(Token))
            {
                this.AddNotification("Token", "Informe o Token");
            }
            else
            {
                if (this.Token.Length < 50)
                {
                    this.AddNotification("Token", "Informe um Token válido.");
                }
            }

            if (String.IsNullOrEmpty(RefreshToken))
            {
                this.AddNotification("Refresh Token", "Informe o Refresh Token");
            }
            else
            {
                if (this.RefreshToken.Length > 50)
                {
                    this.AddNotification("Refresh Token", "Informe um Refresh Token válido.");
                }
            }
        }
    }
}