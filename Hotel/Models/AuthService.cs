using BCrypt.Net;
using Hotel.Data;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Models
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public (bool IsValid, string Role) ValidateUser(string username, string password)
        {
            var staffLogin = _context.StaffLogins
                .Include(sl => sl.Staff)
                .FirstOrDefault(sl => sl.UserName == username);

            if (staffLogin == null) return (false, null);

            if (VerifyPassword(password, staffLogin.Password))
            {
                return (true, staffLogin.Staff.Role);
            }

            return (false, null);
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
