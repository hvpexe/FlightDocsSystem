using AutoMapper;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupVM>();
            CreateMap<GroupVM, Group>();
            //CreateMap<GroupModel, Group>();
            //CreateMap<Group, GroupModel>();
        }
    }
}
