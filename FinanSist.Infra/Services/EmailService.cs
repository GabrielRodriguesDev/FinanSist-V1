using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using FinanSist.Domain.Commands.Email;
using FinanSist.Domain.Interfaces.Infrastructure;

namespace FinanSist.Infra.Services
{
    public class EmailService : IEmailService
    {
        public bool Enviar(MensagemEmailCommand mensagem)
        {
            //cria uma mensagem
            MailMessage mail = new MailMessage();

            //define os endereços
            mail.From = new MailAddress(mensagem.De, "Teste - Gabriel", System.Text.Encoding.UTF8);

            foreach (var item in mensagem.Destinatarios)
            {
                mail.To.Add(item);
            }

            //define o conteúdo
            mail.Subject = mensagem.Assunto;
            mail.Body = mensagem.Corpo;
            mail.IsBodyHtml = mensagem.Html;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Priority = MailPriority.High;
            //envia a mensagem
            SmtpClient smtp = new SmtpClient("", 587);
            smtp.Credentials = new NetworkCredential("", "");
            smtp.EnableSsl = false;
            smtp.Send(mail);
            return true;
        }
    }
}