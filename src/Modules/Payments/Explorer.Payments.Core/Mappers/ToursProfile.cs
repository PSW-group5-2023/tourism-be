using AutoMapper;
using Explorer.Tours.API.Dtos;
using Explorer.Payments.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Mappers
{
    public class ToursProfile : Profile
    {
        public ToursProfile()
        {
            CreateMap<TourDto, ListedTourDto>().ReverseMap();
            CreateMap<TourDurationDto, ListedTourDurationDto>().ReverseMap();
            CreateMap<TourKeyPointDto, ListedTourKeyPointDto>().ReverseMap();
        }
    }
}
