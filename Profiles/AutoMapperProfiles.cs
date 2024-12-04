using AutoMapper;
using NupsiSign.Models.DbSet;
using NupsiSign.Models.Dtos;

namespace AcademicShare.Web.Profiles;

public class AutoMapperProfiles : Profile
{   
    public AutoMapperProfiles()
    {
        CreateMap<CreateUser, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => true))
            .ReverseMap();
    }
}
