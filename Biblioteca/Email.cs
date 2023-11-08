using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Email
    {

        public static void SendEmail(string email, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.yopmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("administrador@yopmail.com", "");
            smtpClient.EnableSsl = true;

            var message = new MailMessage();
            message.From = new MailAddress("tucorreo@gmail.com");
            message.To.Add(new MailAddress(email));
            message.Subject = subject;
            message.Body = body;


            try
            {
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
