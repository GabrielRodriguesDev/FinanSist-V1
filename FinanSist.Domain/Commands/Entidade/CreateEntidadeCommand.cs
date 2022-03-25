using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Interfaces.Commands;
using FinanSist.Domain.Notifications;

namespace FinanSist.Domain.Commands.Entidade
{
    public class CreateEntidadeCommand : Notificable, ICommand
    {
        public String Nome { get; set; } = null!;
        public String Descricao { get; set; } = null!;

        public override void Validate()
        {
            if (String.IsNullOrEmpty(this.Nome))
            {
                this.AddNotification("Nome", "Informe o Nome.");
            }
            else
            {
                if (this.Nome.Length > 120)
                {
                    this.AddNotification("Nome", "Nome deve conter no máximo 120 caracteres.");
                }
            }

            if (String.IsNullOrEmpty(this.Descricao))
            {
                this.AddNotification("Nome", "Informe a Descrição.");
            }
            else
            {
                if (this.Nome.Length > 120)
                {
                    this.AddNotification("Nome", "Descrição deve conter no máximo 200 caracteres.");
                }
            }
        }
    }
}