using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestArchitectureReviewOne.Domain.Notifications;

namespace TestArchitectureReviewOne.Domain.Commands.Entidade
{
    public class UpdateEntidadeCommand : Notificable
    {

        #region  Property

        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        #endregion

        #region Method
        public override void Validate()
        {
            if (this.Id == null)
            {
                this.AddNotification("Id", "Informe o Id");
            }
            if (String.IsNullOrEmpty(this.Nome))
            {
                this.AddNotification("Nome", "Informe o nome");
            }
            else
            {
                if (this.Nome.Length > 60)
                {
                    this.AddNotification("Nome", "Nome deve conter no máximo 60 caracteres");
                }
            }
        }
        #endregion
    }
}