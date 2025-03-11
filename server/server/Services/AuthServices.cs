using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using server.Context;
using server.Entities;
using server.Models;

namespace server.Services
{
    public class AuthServices(UserDbContext context) : IAuthServices
    {
        public async Task<User?> RegisterAsync(UserDto request)
        {

            if (await context.User.AnyAsync(u => u.Username == request.Username))
            {
                return null;
            }

            var user = new User();
            var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);
            user.Username = request.Username;
            user.Email = request.Email;
            user.PasswordHash = hashedPassword;

            context.User.Add(user);
            await context.SaveChangesAsync();


            return user;
        }

    }
}
