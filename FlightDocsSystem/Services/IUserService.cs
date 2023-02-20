using FlightDocsSystem.Models;

namespace FlightDocsSystem.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        void Delete(int id);
        User GetUser(int id);
        void UpsertUser(User user);
    }
}
