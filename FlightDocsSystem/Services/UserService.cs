using FlightDocsSystem.Models;
using Microsoft.IdentityModel.Tokens;

namespace FlightDocsSystem.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(int id)
        {
            User user = _context.Users.Find(id);
            return user;
        }

        public void UpsertUser(User user)
        {
            var dbUser = GetUser(user.Id);
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
            }
            _context.Users.Update(dbUser);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetUser(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
