using AutoMapper;
using BIT_DataAccess.Data;
using BIT_Models;

namespace BIT_Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TicketDTO, Ticket>().ReverseMap();
            CreateMap<ProjectDTO, Project>().ReverseMap();
            //CreateMap<BIT_DataAccess.Data.File, FileDTO>().ReverseMap();
        }
    }
}
