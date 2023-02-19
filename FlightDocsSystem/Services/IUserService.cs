using FlightDocsSystem.Models;

namespace FlightDocsSystem.Services
{
    public interface IUserService
    {
        void CreateUser(User user);

        User GetUser(int id);
    }
}
