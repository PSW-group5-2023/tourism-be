﻿using AutoMapper;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.Domain.Sessions;
using Explorer.Tours.API.Dtos.Statistics;
using Explorer.Tours.API.Dtos.Equipment;
using Explorer.Tours.API.Dtos.Facility;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Dtos.Rating;
using Explorer.Tours.API.Dtos.Execution;
using Explorer.Tours.API.Dtos.Problem;
using Explorer.Tours.Core.Domain.Equipment;
using Explorer.Tours.Core.Domain.Problem;
using Explorer.Tours.Core.Domain.Rating;
using Explorer.Tours.Core.Domain.Facilities;
using Explorer.Tours.API.Dtos.Tour.Tourist;
using Explorer.Tours.API.Dtos.Execution.Tourist;

namespace Explorer.Tours.Core.Mappers;

public class ToursProfile : Profile
{
    public ToursProfile()
    {
        CreateMap<EquipmentDto, Equipment>().ReverseMap();
        CreateMap<TourDto, Tour>().ReverseMap();
        CreateMap<CheckpointDto, Checkpoint>().ReverseMap();
        CreateMap<TourRatingDto, TourRating>().ReverseMap();
        CreateMap<FacilityDto, Facility>().ReverseMap();
        CreateMap<TourProblemMessageDto, TourProblemMessage>().ReverseMap();

        CreateMap<TourProblemDto, TourProblem>()
            .IncludeAllDerived()
            .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages.Select((dto) => new TourProblemMessage(dto.SenderId,dto.RecipientId, dto.CreationTime, dto.Description,dto.IsRead))));
        CreateMap<TourProblem, TourProblemDto>()
            .IncludeAllDerived()
            .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages.Select((message) => new TourProblemMessageDto { SenderId = message.SenderId, RecipientId = message.RecipientId, CreationTime = message.CreationTime, Description = message.Description,IsRead = message.IsRead })));

        CreateMap<PositionSimulatorDto, PositionSimulator>().ReverseMap();
        CreateMap<PreferencesDto, Preferences>().ReverseMap();
        CreateMap<CompletedKeyPointDto, CompletedKeyPoint>().ReverseMap();

        CreateMap<SessionDto, Session>().ReverseMap();
        CreateMap<SessionDto, Session>().IncludeAllDerived()
            .ForMember(dest => dest.CompletedKeyPoints, opt => opt.MapFrom(src => src.CompletedKeyPoints.Select((completedKeyPoint) => new CompletedKeyPoint(completedKeyPoint.KeyPointId, completedKeyPoint.CompletionTime))));
        CreateMap<SessionMobileDto, Session>().ReverseMap();


        CreateMap<EquipmentTrackingDto, EquipmentTracking>().ReverseMap();
        CreateMap<PublicCheckpointDto, PublicCheckpoint>().ReverseMap().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        CreateMap<PublicFacilityDto, PublicFacility>().ReverseMap().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        CreateMap<TourStatisticsDto, TourStatisticsDto>().ReverseMap();
        CreateMap<TourDuration, TourDurationDto>().ReverseMap();
        CreateMap<TourRating, TourRatingMobileDto>().ReverseMap();


        CreateMap<Tour, TourMobileDto>().ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(uri => uri.ToString()).ToList()));
        CreateMap<TourMobileDto, Tour>().ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(img => new Uri(img)).ToList()));
        CreateMap<TourMobileDto, TourRating>().ReverseMap().ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Mark));
        CreateMap<CheckpointMobileDto, Checkpoint>().ReverseMap();
        CreateMap<CheckpointMobileDto, Checkpoint>().ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image.Select(uri => uri.ToString()))); //mozda su ovakve stvari nepotrebne


    }
}