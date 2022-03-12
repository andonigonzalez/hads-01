using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Email
    {
        private MailMessage mail = new MailMessage();
        private SmtpClient smtp = new SmtpClient();

        public Email()
        {
            mail.From = new MailAddress("agonzalez330@ikasle.ehu.es");
            smtp.Host = "smtp.ehu.eus";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("agonzalez330", "{password}");
            smtp.EnableSsl = true;
        }

        public void Crear(string to, string subject, string body)
        {
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
        }

        public void Enviar()
        {
            smtp.Send(mail);
        }
    }
}
