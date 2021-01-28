
using System;
using System.Collections.Generic;

namespace Equinox.Domain.Interfaces
{
    public interface IEmailSender
    {
        void Enviar(string destinatario, string assunto, string mensagem);
    }
}

