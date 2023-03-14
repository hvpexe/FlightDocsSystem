using FlightDocsSystem.Models;
using Microsoft.IdentityModel.Tokens;

namespace FlightDocsSystem.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async ValueTask<User?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task UpsertUserAsync(User user)
        {
            var dbUser = await GetUserByIdAsync(user.Id);
            if (dbUser != null)
            {
                if (!string.IsNullOrEmpty(user.Name))
                    dbUser.Name = user.Name;
                if (!string.IsNullOrEmpty(user.Email))
                    dbUser.Email = user.Email;
                if (!string.IsNullOrEmpty(user.Phone))
                    dbUser.Phone = user.Phone;
                if (!string.IsNullOrEmpty(user.Permission))
                    dbUser.Permission = user.Permission;

                _context.Users.Update(dbUser);
                _context.SaveChanges();
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public async Task<User> LoginAsync(LoginModel model)
        {
            var user = await _context.Users.SingleOrDefaultAsync(p => p.Email == model.Email && model.Password == model.Password);
            return user;
        }
    }
}
