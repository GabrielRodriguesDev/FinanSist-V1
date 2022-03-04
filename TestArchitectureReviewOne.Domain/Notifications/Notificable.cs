using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestArchitectureReviewOne.Domain.Notifications
{
    public abstract class Notificable
    {
        //Notificável é a classe que gera a notificação


        #region  Property
#nullable disable
        public List<Notification> Notifications { get; private set; } //Propriedade que pode alocar uma lista de notifications.
        #endregion

        #region  Methods
        public void AddNotification(string key, string value) // Adiciona notificações na lista.
        {
            this.Notifications.Add(new Notification(key, value));
        }

        public void ClearNotificaion() // Limpa a lista de notificações.
        {
            this.Notifications.Clear();
        }

        public bool IsValid // Retornar true se a lista de notificações estiver vázia.
        {
            get { return this.Notifications.Count() == 0; }
        }

        public bool Invalid // Retorna true se a lista de notificações tiver um registro.
        {
            get { return this.Notifications.Count() > 0; }
        }


        public abstract void Validate(); // Método abstrato que vai ser sobreescrevido na classe derivada.

        #endregion

    }
}