using System.Text.Json.Serialization;

namespace RiskTrackSCF_UserCreatorAPI.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public string? RUC { get; set; }
        public string? Sector { get; set; }

        [JsonIgnore]
        public ICollection<User>? Users { get; set; } 
    }
}
