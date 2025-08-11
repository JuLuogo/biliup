using System;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace Biliup.Notifications
{
    public class EmailNotifier : INotifier
    {
        public async Task SendAsync(string message, string smtpConfig)
        {
            // smtpConfig format: smtpServer:port:user:pass:toEmail
            var parts = smtpConfig.Split(':');
            if (parts.Length != 5) throw new ArgumentException("Invalid SMTP config");

            var smtp = new SmtpClient(parts[0], int.Parse(parts[1]))
            {
                Credentials = new NetworkCredential(parts[2], parts[3]),
                EnableSsl = true
            };

            var mail = new MailMessage(parts[2], parts[4], "Upload Notification", message);
            await smtp.SendMailAsync(mail);
        }
    }
}