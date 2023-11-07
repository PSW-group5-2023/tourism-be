using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain;

namespace Explorer.Tours.Core.Mappers;

public class ToursProfile : Profile
{
    public ToursProfile()
    {
        CreateMap<EquipmentDto, Equipment>().ReverseMap();
        CreateMap<TourDto, Tour>().ReverseMap();
        CreateMap<TourKeyPointDto, TourKeyPoint>().ReverseMap();
        CreateMap<TourRatingDto, TourRating>().ReverseMap();
        CreateMap<FacilityDto, Facility>().ReverseMap();
        CreateMap<TourProblemDto, TourProblem>().ReverseMap();
        CreateMap<PositionSimulatorDto, PositionSimulator>().ReverseMap();
        CreateMap<PreferencesDto, Preferences>().ReverseMap();
        CreateMap<PublicTourKeyPointDto, PublicTourKeyPoints>().ReverseMap().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        CreateMap<PublicFacilityDto, PublicFacility>().ReverseMap().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        CreateMap<BoughtItemDto,BoughtItem>().ReverseMap();
        CreateMap<BoughtItemDto, BoughtItem>().ReverseMap();
    }
}