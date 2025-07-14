namespace RiskTrackSCF_UserCreatorAPI.Contracts
{
    public record UserCreated
    {
        public string Username { get; init; }=string.Empty;
        public string Email { get; init; }=string.Empty;
    }
}
