using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Entities;

namespace FinanSist.Domain.Commands.Email
{
    public class CreatePostEsqueceuSenhaCommand
    {
        public static MensagemEmailCommand Create(FinanSist.Domain.Entities.Usuario usuario)
        {
            MensagemEmailCommand msg = new MensagemEmailCommand();
            msg.Destinatarios.Add(usuario.Email);

            msg.Assunto = $"Bom ter você de volta, {usuario.Nome.Split(" ")[0]}";
            //msg.De = Environment.GetEnvironmentVariable("NomeDeEmail")!;
            msg.De = "gabriel@gabriel.com.br";
            msg.Html = true;
            //var domain = Environment.GetEnvironmentVariable("Domain");
            msg.Corpo = $@"<p>Olá, {usuario.Nome}</p><p><br><p>Token: {usuario.TokenSenha} <br><p>*Este link expira em 30 minutos</p>";


            return msg;

        }
    }
}