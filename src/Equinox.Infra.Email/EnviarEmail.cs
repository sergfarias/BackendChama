using Microsoft.Extensions.Options;
using Equinox.Domain.Interfaces;
using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Equinox.Infra.Email
{
    public class EnviarEmail : IEmailSender
    {
        private SmtpClient SmtpClient;
        private NetworkCredential Networkcredential;

        public EnviarEmail(IOptions<EmailSettings> emailSettings)
        {
            var _emailSettings = emailSettings.Value;

            SmtpClient = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort);
            Networkcredential = new NetworkCredential(_emailSettings.PrimaryEmail, _emailSettings.PrimaryPassword);
            
            SmtpClient.EnableSsl = true; 
            SmtpClient.Credentials = Networkcredential;
            SmtpClient.UseDefaultCredentials = true;
        }

        public void Enviar(string destinatario, string assunto, string mensagem)
        {
            if (ValidaEnderecoEmail(Networkcredential.UserName)) 
                throw new Exception("O e-mail cadastrado como credencial não é valido. Entre em contato com o suporte.");
                
            if (ValidaEnderecoEmail(destinatario))
            {
                var emailArrumado = ArrumarEmail(destinatario);

                throw new Exception("O e-mail do destinatário "+ emailArrumado +" não é valido. Entre em contato com o suporte.");
            }
                
            MailMessage mensagemEmail = new MailMessage(Networkcredential.UserName, destinatario, assunto, mensagem)
            {
                IsBodyHtml = true
            };

            SmtpClient.Send(mensagemEmail);
        }

        public bool ValidaEnderecoEmail(string enderecoEmail)
        {
            if (string.IsNullOrEmpty(enderecoEmail) || string.IsNullOrWhiteSpace(enderecoEmail)) 
                return true;

            Regex expressaoRegex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            return !expressaoRegex.IsMatch(enderecoEmail);
        }

        public string ArrumarEmail(string email)
        {
            var posicao = email.IndexOf("@");
            if(posicao <= 0)
            {
                return "";
            }

            var pedacoEmail = email.Substring(1, posicao - 2);
            string trocar = "";
            for (int i = 0; i <= pedacoEmail.Length; i++)
            {
                trocar += "*";
            }
            var restoEmail = email.Substring(posicao - 1);
            return email.Substring(0, 1) + trocar + restoEmail;
        }
    }
}
