using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.API.Dtos;

namespace Explorer.Stakeholders.Core.Mappers;

public class StakeholderProfile : Profile
{
    public StakeholderProfile()
    {
        CreateMap<UserInformationDto, User>().ReverseMap().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
        CreateMap<UserInformationDto, Person>().ReverseMap();
        CreateMap<PersonDto, Person>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
    }
}