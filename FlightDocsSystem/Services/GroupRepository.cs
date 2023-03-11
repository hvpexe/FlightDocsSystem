using AutoMapper;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.Services
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GroupRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GroupVM> AddGroupAsync(GroupModel group)
        {
            Group newGroup = new Group
            {
                Name = group.Name,
                CreatedDate = DateTime.UtcNow,
                Note = group.Note,
            };
            await _context.Groups.AddAsync(newGroup);
            await _context.SaveChangesAsync();

            var returnGroup = _mapper.Map<GroupVM>(newGroup);
            return returnGroup;
        }

        public async Task DeleteGroupAsync(int id)
        {
            var group = await _context.Groups.SingleOrDefaultAsync(gr => gr.Id == id);
            if (group != null)
            {
                _context.Remove(group);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<GroupVM>> GetAllGroupAsync()
        {
            var groups = await _context.Groups.ToListAsync();
            return _mapper.Map<List<GroupVM>>(groups);
        }
        public async Task<GroupVM> GetGroupByIdAsync(int id)
        {
            var group = await _context.Groups.SingleOrDefaultAsync(gr => gr.Id == id);
            if (group != null)
            {
                return _mapper.Map<GroupVM>(group);
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
