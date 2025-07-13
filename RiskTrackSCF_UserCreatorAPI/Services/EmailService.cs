using MimeKit;
using MimeKit.Text;
using MailKit.Security; 
using Microsoft.Extensions.Configuration;

namespace RiskTrackSCF_UserCreatorAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string htmlContent)
        {
            var smtpSettings = _config.GetSection("Smtp");

            var email = new MimeMessage();

            email.From.Add(new MailboxAddress(smtpSettings["SenderName"], smtpSettings["User"]));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = htmlContent
            };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;

            await smtp.ConnectAsync(smtpSettings["Host"], int.Parse(smtpSettings["Port"]!), SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(smtpSettings["User"], smtpSettings["Password"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}