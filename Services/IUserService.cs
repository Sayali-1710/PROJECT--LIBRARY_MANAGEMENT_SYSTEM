using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.DTOs;

namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Services
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterRequest request);
        Task<string> LoginAsync(LoginRequest request);
        Task RegisterAsync(Microsoft.AspNetCore.Identity.Data.RegisterRequest req);
        Task LoginAsync(Microsoft.AspNetCore.Identity.Data.LoginRequest req);
    }
}
