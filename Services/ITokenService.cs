using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Models;

namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
