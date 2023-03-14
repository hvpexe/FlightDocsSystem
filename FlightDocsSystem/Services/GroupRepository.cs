using AutoMapper;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.Services
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DataContext _context;

        public GroupRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateGroupAsync(GroupModel group)
        {
            Group newGroup = new Group
            {
                Name = group.Name,
                CreatedDate = DateTime.UtcNow,
                Note = group.Note,
            };
            await _context.Groups.AddAsync(newGroup);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(int id)
        {
            var group = await _context.Groups.SingleOrDefaultAsync(gr => gr.Id == id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Group>> GetAllGroupAsync()
        {
            var groups = await _context.Groups.ToListAsync();
            return groups;
        }
        public async Task<Group?> GetGroupByIdAsync(int id)
        {
            var group = await _context.Groups.SingleOrDefaultAsync(gr => gr.Id == id);
            if (group != null)
            {
                return group;
            }
            return null;
        }

        public async Task UpdateGroupAsync(GroupVM group)
        {
            var newGroup = await _context.Groups.SingleOrDefaultAsync(gr => gr.Id == group.Id);
            if (newGroup != null)
            {
                newGroup.Name = group.Name;
                newGroup.Note = group.Note;
            }

            await _context.SaveChangesAsync();  
        }
    }
}
