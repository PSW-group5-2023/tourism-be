﻿using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases
{
    public class TourService : CrudService<TourDto, Tour>, ITourService
    {

        public TourService(ICrudRepository<Tour> repository, IMapper mapper) : base(repository, mapper)
        {
            
        }

        /*public Result<TourDto> Archive(int id)
        {
            var tourDTO = Get(id);
            var tour = MapToDomain(tourDTO.Value);
            tour.Archive();
            var result = Update(MapToDto(tour));
            return result;
        }*/
    }
}
