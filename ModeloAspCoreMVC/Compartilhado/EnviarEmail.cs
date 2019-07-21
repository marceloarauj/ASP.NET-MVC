using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ModeloAspCoreMVC.Compartilhado
{
    public class EnviarEmail
    {
        private const string nossoEmail = "marcelo.araujo@souunit.com.br";

        public static void EnviarMensagem(string mensagem,string destino,string titulo)
        {
            try
            {
                MailMessage email = new MailMessage();

                email.From = new MailAddress(nossoEmail);
                email.To.Add(destino);
                email.Subject = titulo;
                email.Body = mensagem;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = false;

                NetworkCredential credenciais = new NetworkCredential(nossoEmail, "BiohazardX18@");

                smtpClient.Credentials = credenciais;
                
                smtpClient.EnableSsl = true;

                smtpClient.Send(email);
            }catch(Exception e)
            {
                System.Diagnostics.Debug.Write("Erro :" + e.Message);
            }
        }
    }
}
