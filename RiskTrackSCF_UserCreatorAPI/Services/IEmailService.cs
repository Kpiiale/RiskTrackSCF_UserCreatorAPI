namespace RiskTrackSCF_UserCreatorAPI.Services
{
    public interface IEmailService
    {
        // Declara un método asíncrono que cualquier clase que implemente IEmailService debe proporcionar.
        Task SendEmailAsync(string toEmail, string subject, string htmlContent);
    }
}
