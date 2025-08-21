using Microsoft.AspNetCore.Identity.Data;

namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Services
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterRequest request);
        Task<string> LoginAsync(LoginRequest request);
    }
}
