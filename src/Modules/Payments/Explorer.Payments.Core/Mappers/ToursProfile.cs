using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Payments.API.Dtos.ListedTours;
using Explorer.Payments.API.Dtos;
using Explorer.Tours.API.Dtos.Tour;

namespace Explorer.Payments.Core.Mappers
{
    public class ToursProfile : Profile
    {
        public ToursProfile()
        {
            CreateMap<TourDto, ListedTourDto>().ReverseMap();
            CreateMap<TourDurationDto, ListedTourDurationDto>().ReverseMap();
            CreateMap<CheckpointDto, ListedTourKeyPointDto>().ReverseMap();
        }
    }
}
