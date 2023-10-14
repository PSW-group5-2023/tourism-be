using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;

namespace Explorer.Tours.Core.UseCases
{
    public class TourKeyPointService : CrudService<TourKeyPointDto, TourKeyPoint>, ITourKeyPointService
    {
        public TourKeyPointService(ICrudRepository<TourKeyPoint> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
