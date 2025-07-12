namespace RiskTrackSCF_UserCreatorAPI.DTOs
{
    public class CreateUserRequest
    {
        public int? CompanyId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "U"; 
    }
}
