using FlightDocsSystem.Models;

namespace FlightDocsSystem.Services
{
    public interface IUserRepository
    {
        Task<bool> IsEmailExistAsync(string email);
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<List<User>> GetAllUsersAsync(); 
        ValueTask<User?> GetUserByIdAsync(int id);
        Task UpsertUserAsync(User user);
        Task<User> LoginAsync(LoginModel model);
    }
}
