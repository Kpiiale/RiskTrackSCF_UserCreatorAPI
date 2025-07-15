using MassTransit;
using RiskTrackSCF_UserCreatorAPI.Contracts;
using RiskTrackSCF_UserCreatorAPI.Services;

namespace RiskTrackSCF_UserCreatorAPI.Consumers
{
    // Define un "consumidor" que se suscribe y reacciona a los mensajes de tipo 'UserCreated'.
    public class UserCreatedConsumer : IConsumer<UserCreated>
    {
        // Inyección de dependencia del servicio de correo electrónico.
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
            // Utiliza el servicio de correo para enviar una notificación de bienvenida.
            await _emailService.SendEmailAsync(message.Email, subject, htmlBody);
        }
    }
}