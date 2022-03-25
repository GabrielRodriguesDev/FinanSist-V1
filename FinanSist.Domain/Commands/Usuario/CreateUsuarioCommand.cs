using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FinanSist.Domain.Helpers;
using FinanSist.Domain.Interfaces.Commands;
using FinanSist.Domain.Notifications;

namespace FinanSist.Domain.Commands.Usuario
{
    public class CreateUsuarioCommand : Notificable, ICommand
    {
        #region  Property
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;

        private string _Telefone = null!;

        public string Telefone
        {
            get { return _Telefone; }
            set { _Telefone = new Regex(@"[^\d]").Replace(value, ""); }
        }
        #endregion


        #region Method    
        public override void Validate()
        {
            if (String.IsNullOrEmpty(this.Nome))
            {
                this.AddNotification("Nome", "Informe o Nome.");
            }
            else
            {
                if (this.Nome.Length > 120)
                    this.AddNotification("Nome", "Nome deve conter no máximo 120 caracteres.");
            }

            if (String.IsNullOrEmpty(this.Email))
            {
                this.AddNotification("Email", "Informe o email.");
            }
            else
            {
                if (this.Email.Length > 100)
                    this.AddNotification("Email", "Email deve conter no máximo 100 caracteres.");
                if (!ValidationHelper.IsValidEmail(this.Email))
                    this.AddNotification("Email", "Email digitado está inválido.");
            }
            if (string.IsNullOrEmpty(this.Senha))
            {
                this.AddNotification("Senha", "Informe a senha.");
            }
            else
            {
                if (this.Senha.Length < 6)
                {
                    this.AddNotification("Senha", "Senha deve conter no mínimo 6 caracteres.");
                }
                if (!ChecarForcaSenhaHelper.SenhaValida(this.Senha))
                {
                    this.AddNotification("Senha", "Desculpe, essa senha não pode ser cadastrada. (Nível Fraco)");
                }
            }


            if (String.IsNullOrEmpty(this.Telefone))
            {
                this.AddNotification("Telefone", "Informe o Telefone.");
            }
            else
            {
                if (this.Telefone.Length > 30)
                    this.AddNotification("Telefone", "Telefone deve conter no maximo 30 caracteres.");
            }
        }
        #endregion
    }
}