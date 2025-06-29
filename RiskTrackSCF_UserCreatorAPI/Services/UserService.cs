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
            var user = _context.Usuarios.FirstOrDefault(u => u.Email == request.Email && u.Role == "A" && u.IsActive);

            if (user == null)
                return null;

            bool valid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            return valid ? user : null;
        }

        public void CreateUser(CreateUserRequest request)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var newUser = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = hashedPassword,
                Role = request.Role,
                CompanyId = request.CompanyId,
                CreationDate = DateTime.UtcNow,
                IsActive = true
            };

            _context.Usuarios.Add(newUser);
            _context.SaveChanges();
        }
    }
}
