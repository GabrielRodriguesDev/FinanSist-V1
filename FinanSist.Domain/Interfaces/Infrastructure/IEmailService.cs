using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands.Email;

namespace FinanSist.Domain.Interfaces.Infrastructure
{
    public interface IEmailService
    {
        bool Enviar(MensagemEmailCommand mensagem);
    }
}