using MimeKit;
using MimeKit.Text;
using MailKit.Security; 
using Microsoft.Extensions.Configuration;

namespace RiskTrackSCF_UserCreatorAPI.Services
{
    public class EmailService : IEmailService
    {
        // Inyección de dependencia para acceder a la configuración.
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        // Método asíncrono para construir y enviar un correo electrónico.
        public async Task SendEmailAsync(string toEmail, string subject, string htmlContent)
        {
            // Obtiene la configuración del servidor SMTP desde appsettings.json.
            var smtpSettings = _config.GetSection("Smtp");

            var email = new MimeMessage();
            // Establece el remitente (From), el destinatario (To) y el asunto (Subject).
            email.From.Add(new MailboxAddress(smtpSettings["SenderName"], smtpSettings["User"]));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = htmlContent
            };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            // Se conecta al servidor SMTP, se autentica con las credenciales y envía el correo.
            await smtp.ConnectAsync(smtpSettings["Host"], int.Parse(smtpSettings["Port"]!), SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(smtpSettings["User"], smtpSettings["Password"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}