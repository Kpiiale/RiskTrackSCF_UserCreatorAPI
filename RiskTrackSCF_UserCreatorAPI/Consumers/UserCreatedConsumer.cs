using MassTransit;
using RiskTrackSCF_UserCreatorAPI.Contracts;
using RiskTrackSCF_UserCreatorAPI.Services;

namespace RiskTrackSCF_UserCreatorAPI.Consumers
{
    public class UserCreatedConsumer : IConsumer<UserCreated>
    {
        private readonly IEmailService _emailService;

        public UserCreatedConsumer(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Consume(ConsumeContext<UserCreated> context)
        {
            var message = context.Message;

            var subject = "¡Bienvenido a RiskTrack";
            var htmlBody = $"<h2>Hola {message.Username},</h2><p>Tu cuenta ha sido creada exitosamente. Puedes Iniciar Sesión con normalidad</p>";

            await _emailService.SendEmailAsync(message.Email, subject, htmlBody);
        }
    }
}