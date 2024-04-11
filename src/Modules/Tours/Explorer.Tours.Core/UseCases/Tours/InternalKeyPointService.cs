using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Internal;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Tours
{
    public class InternalKeyPointService : BaseService<TourKeyPointDto, TourKeyPoint>, IInternalKeyPointService
    {
        public ITourKeyPointsRepository _tourKeyPointRepository;
        public ITourService _tourService;

        public InternalKeyPointService(ITourKeyPointsRepository tourKeyPointsRepository, ITourService tourService, IMapper mapper) : base(mapper)
        {
            _tourKeyPointRepository = tourKeyPointsRepository;
            _tourService = tourService;
        }

        public Result<TourKeyPointDto> Get(long id)
        {
            return MapToDto(_tourKeyPointRepository.Get(id));
        }

        public Result<bool> CheckIfUserIsAuthor(long authorId, long keypointId)
        {
            TourKeyPoint tourKeyPoint = _tourKeyPointRepository.Get(keypointId);

            if(tourKeyPoint.TourId != null)
            {
                TourDto tourDto = _tourService.GetById((long)tourKeyPoint.TourId).Value;
                return authorId == tourDto.AuthorId;
            }
            return false;
        }
    }
}
