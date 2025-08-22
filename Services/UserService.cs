using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.DTOs;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Models;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Repository;
namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Services
{
    public class UserService: IUserService
    {
        private readonly IGenericRepository<User> _userRepo;
        private readonly LibraryContext _context;
        private readonly ITokenService _tokenService;
        public UserService(IGenericRepository<User>userRepo,LibraryContext context,ITokenService tokenService)
        {
            _userRepo = userRepo;
            _context = context;
            _tokenService = tokenService;
        }
        //Register
        public async Task RegisterAsync(RegisterRequest request)
        {
            var exists = (await _context.Users.AnyAsync(u => u.Email==request.Email));
            if (exists)
                throw new Exception(" Email already registered ");
            var user = new User
            {
                Name=request.Name,
                Email=request.Email,
                Role=request.Role,
                Password=BCrypt.Net.BCrypt.HashPassword(request.Password)
            };
            await _userRepo.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        //Login
        public async Task<string> LoginAsync(LoginRequest request)
        {
            var user = await  _context.Users.FirstOrDefaultAsync(u => u. Email==request .Email);
            if (user==null)
                throw new Exception("Invalid Credentials");
            var valid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
            if (!valid) throw new Exception("Invalid credentials");
            return _tokenService.GenerateToken(user);
        }

        public Task RegisterAsync(Microsoft.AspNetCore.Identity.Data.RegisterRequest req)
        {
            throw new NotImplementedException();
        }

        public Task LoginAsync(Microsoft.AspNetCore.Identity.Data.LoginRequest req)
        {
            throw new NotImplementedException();
        }
    }
}
