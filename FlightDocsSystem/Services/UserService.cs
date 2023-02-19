using FlightDocsSystem.Models;

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
            Console.WriteLine("check at service");
        }

        public User GetUser(int id)
        {
            User user = _context.Users.Find(id);
            return user;
        }
    }
}
