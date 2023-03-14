using FlightDocsSystem.Models;

namespace FlightDocsSystem.Services
{
    public interface IGroupRepository
    {
        Task<List<Group>> GetAllGroupAsync();
        Task<Group?> GetGroupByIdAsync(int id);
        Task CreateGroupAsync(GroupModel group);
        Task UpdateGroupAsync(GroupVM group);
        Task DeleteGroupAsync(int id);
    }
}
