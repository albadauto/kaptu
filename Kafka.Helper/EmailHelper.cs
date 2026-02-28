using System.Net;
using System.Net.Mail;

namespace Kaptu.Helper
{
    public static class EmailHelper
    {
        public static void SendMail(string mailToSend, string message, string subject)
        {
            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("contact.qnext@gmail.com", "otsgytfpwmbynqxw"),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress("contact.qnext@gmail.com"),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mail.To.Add(mailToSend);

            smtp.Send(mail);
        }
    }
}
