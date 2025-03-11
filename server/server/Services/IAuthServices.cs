using server.Entities;
using server.Models;

namespace server.Services
{
    public interface IAuthServices
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<string?> LoginAsync(UserDto request);
    }
}
