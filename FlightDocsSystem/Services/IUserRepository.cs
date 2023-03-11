namespace FlightDocsSystem.Services
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void Delete(int id);
        User GetUser(int id);
        void UpsertUser(User user);
    }
}
