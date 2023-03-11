using FlightDocsSystem.Models;

namespace FlightDocsSystem.Services
{
    public interface IGroupRepository
    {
        Task<List<GroupVM>> GetAllGroupAsync();
        Task<GroupVM> GetGroupByIdAsync(int id);
        Task<GroupVM> AddGroupAsync(GroupModel group);
        Task UpdateGroupAsync(GroupVM group);
        Task DeleteGroupAsync(int id);
    }
}
