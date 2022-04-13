using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Helpers.Enums;
using FinanSist.Domain.Interfaces.Commands;
using FinanSist.Domain.Notifications;

namespace FinanSist.Domain.Commands.Categorias
{
    public class UpdateCategoriaCommand : Notificable, ICommand
    {
        public Guid? Id { get; set; }
        public String Nome { get; set; } = null!;
        public int? Tipo { get; set; }
        public bool Ativo { get; set; }
        public override void Validate()
        {
            if (this.Id == null)
            {
                this.AddNotification("Id", "Informe o Id.");
            }
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

            if (this.Tipo == null)
            {
                this.AddNotification("Tipo", "Informe o tipo.");
            }
            else
            {
                bool result = false;
                foreach (var tipoCategoria in Enum.GetValues(typeof(TipoCategoriaEnum)))
                {
                    if (this.Tipo == (int)tipoCategoria)
                    {
                        result = true;
                    }
                }
                if (result == false)
                {
                    this.AddNotification("Tipo", "Informe um tipo de categoria válido.");
                }
                if (this.Tipo != 0 && this.Tipo != 1)
                {
                    this.AddNotification("Tipo", "Informe um tipo de categoria válido para despesa.");
                }
            }
        }
    }
}