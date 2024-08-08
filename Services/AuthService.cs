using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using TestProject.Context;
using TestProject.Interfaces;
using TestProject.Models;

namespace TestProject.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(ApplicationContext context, IPasswordHasher<User> passwordHasher,IMapper mapper)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<User> LoginAsync(LoginModel model)
        {
            if (model.Email == null || model.Password == null)
                return null;

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == model.Email);

            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password) != PasswordVerificationResult.Success)
            {
                return null;
            }

            return user;
        }

        public async Task<bool> RegisterAsync(RegisterModel model)
        {
            try
            {
                if (await _context.Users.AnyAsync(u => u.Name == model.Name))
                    return false;

                var user = _mapper.Map<User>(model);

                user.Password = _passwordHasher.HashPassword(user, model.Password);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task LogoutAsync()
        {
            return Task.CompletedTask;
        }
    }
}
