namespace Hotel.Models
{
    public interface IAuthService
    {
        (bool IsValid, string Role) ValidateUser(string username, string password);
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
