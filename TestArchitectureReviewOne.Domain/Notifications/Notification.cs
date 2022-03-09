using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestArchitectureReviewOne.Domain.Notifications
{
    public class Notification
    {
        // Classe que molda a notificação
        #region Constructor
        public Notification(string key, string value)
        {
            // Construtor garantindo que toda vez que essa classe seja iniciada seja criado o objeto completo
            this.Key = key;
            this.Value = value;
        }
        #endregion

        #region Property
        public string Key { get; set; } //Chave da notificação (Pode ser um id ou um código como desejar)
        public string Value { get; set; } //Valor da notificação (Mensagem)
        #endregion
    }
}