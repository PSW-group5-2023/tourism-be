﻿using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.Domain.Sessions;
using System.ComponentModel.DataAnnotations;

namespace Explorer.Tours.Core.Mappers;

public class ToursProfile : Profile
{
    public ToursProfile()
    {
        CreateMap<EquipmentDto, Equipment>().ReverseMap();
        CreateMap<TourDto, Tour>().ReverseMap();
        CreateMap<TourDurationDto, TourDuration>().ReverseMap();
        CreateMap<TourKeyPointDto, TourKeyPoint>().ReverseMap();
        CreateMap<TourRatingDto, TourRating>().ReverseMap();
        CreateMap<FacilityDto, Facility>().ReverseMap();
        CreateMap<TourProblemDto, TourProblem>().ReverseMap();
        CreateMap<PositionSimulatorDto, PositionSimulator>().ReverseMap();
        CreateMap<PreferencesDto, Preferences>().ReverseMap();
        CreateMap<CompletedKeyPointDto, CompletedKeyPoint>().ReverseMap();
        CreateMap<SessionDto, Session>().IncludeAllDerived()
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new PositionSimulator(src.Location.Latitude, src.Location.Longitude)))
            .ForMember(dest => dest.CompletedKeyPoints, opt => opt.MapFrom(src => src.CompletedKeyPoints.Select((completedKeyPoint) => new CompletedKeyPoint(completedKeyPoint.KeyPointId, completedKeyPoint.CompletionTime))));
        CreateMap<Session, SessionDto>().IncludeAllDerived()
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));

        CreateMap<EquipmentTrackingDto, EquipmentTracking>().ReverseMap();
        CreateMap<PublicTourKeyPointDto, PublicTourKeyPoints>().ReverseMap().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        CreateMap<PublicFacilityDto, PublicFacility>().ReverseMap().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        CreateMap<BoughtItemDto,BoughtItem>().ReverseMap();

    }
}