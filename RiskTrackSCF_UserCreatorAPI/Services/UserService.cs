using RiskTrackSCF_UserCreatorAPI.Data;
using RiskTrackSCF_UserCreatorAPI.DTOs;
using RiskTrackSCF_UserCreatorAPI.Models;

namespace RiskTrackSCF_UserCreatorAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User? Authenticate(LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == request.Email && u.Role == "S");

            if (user == null)
                return null;

            bool valid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
            return valid ? user : null;
        }

        public void CreateUser(CreateUserRequest request)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var newUser = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = hashedPassword,
                Role = request.Role,
                CompanyId = request.CompanyId,
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
