using RiskTrackSCF_UserCreatorAPI.DTOs;
using RiskTrackSCF_UserCreatorAPI.Models;

namespace RiskTrackSCF_UserCreatorAPI.Services
{
    public interface IUserService
    {
        User? Authenticate(LoginRequest request);
        void CreateUser(CreateUserRequest request);
    }
}
