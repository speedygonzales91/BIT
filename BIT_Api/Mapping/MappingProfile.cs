using AutoMapper;
using BIT_DataAccess.Data;
using BIT_Models;

namespace BIT_Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TicketDTO, Ticket>().ReverseMap();
            CreateMap<ProjectDTO, Project>().ReverseMap();
            CreateMap<CommentDTO, Comment>().ReverseMap();
            //CreateMap<BIT_DataAccess.Data.File, FileDTO>().ReverseMap();
        }
    }
}
