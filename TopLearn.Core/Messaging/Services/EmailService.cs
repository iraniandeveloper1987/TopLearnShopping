using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using TopLearn.Core.messaging.Interfaces;

namespace TopLearn.Core.messaging.Services
{
    public class EmailService : IMessaging
    {

        public void Send(string to, string subject, string message)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("iraniandeveloper.net@gmail.com");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("iraniandeveloper.net@gmail.com", "a811156j");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }


    }
}
