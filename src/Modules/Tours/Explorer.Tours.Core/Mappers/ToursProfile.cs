using AutoMapper;
using Explorer.Blog.Core.Domain;
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
       // CreateMap<TourProblemDto, TourProblem>().ReverseMap();
        CreateMap<TourProblemMessageDto, TourProblemMessage>().ReverseMap();
        CreateMap<TourProblemDto, TourProblem>()
            .IncludeAllDerived()
            .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages.Select((dto) => new TourProblemMessage(dto.UserId, dto.CreationTime, dto.Description))));
        CreateMap<TourProblem, TourProblemDto>()
            .IncludeAllDerived()
            .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages.Select((message) => new TourProblemMessageDto { UserId = message.UserId, CreationTime = message.CreationTime, Description = message.Description })));



        CreateMap<PositionSimulatorDto, PositionSimulator>().ReverseMap();
        CreateMap<PreferencesDto, Preferences>().ReverseMap();

        CreateMap<EquipmentTrackingDto, EquipmentTracking>().ReverseMap();

        CreateMap<PublicTourKeyPointDto, PublicTourKeyPoints>().ReverseMap().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        CreateMap<PublicFacilityDto, PublicFacility>().ReverseMap().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        CreateMap<BoughtItemDto,BoughtItem>().ReverseMap();

    }
}