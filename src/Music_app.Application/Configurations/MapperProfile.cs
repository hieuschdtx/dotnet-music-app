using AutoMapper;
using Music_app.Domain.Entities;
using Music_app.Domain.Models;

namespace Music_app.Application.Configurations
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Roles, RoleDto>().ReverseMap();
        }
    }
}