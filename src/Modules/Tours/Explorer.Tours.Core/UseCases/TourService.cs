using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;

namespace Explorer.Tours.Core.UseCases
{
    public class TourService : CrudService<TourDto, Tour>, ITourService
    {
        private readonly ITourRepository _tourRepository;

        public TourService(ITourRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _tourRepository = repository;
        }

        public Result<TourDto> GetWithKeyPoints(int id)
        {
            try
            {
                var result = _tourRepository.GetWithKeyPoints(id);
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<TourDto> Publish(int id)
        {
            var tour = _tourRepository.GetWithKeyPoints(id);
            tour.Publish();
            _tourRepository.SaveChanges();
            return MapToDto(tour);
        }
    }
}
