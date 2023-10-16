using AutoMapper;
using Explorer.Stakeholders.API.Dtos;

namespace Explorer.Stakeholders.Core.Mappers;

public class StakeholderProfile : Profile
{
    public StakeholderProfile()
    {
        CreateMap<TourPreferencesDto, TourPreferences>().ReverseMap();
    }
}