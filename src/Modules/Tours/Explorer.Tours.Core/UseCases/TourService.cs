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

        public Result<TourDto> Archive(int id, int userId)
        {
            try
            {
                var tour = _tourRepository.Get(id);
                tour.Archive(userId);
                _tourRepository.SaveChanges();
                return MapToDto(tour);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                return Result.Fail(FailureCode.Forbidden).WithError(e.Message);
            }
        }

        public Result<TourDto> Publish(int id, int userId)
        {
            try
            {
                var tour = _tourRepository.Get(id);
                tour.Publish(userId);
                _tourRepository.SaveChanges();
                return MapToDto(tour);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                return Result.Fail(FailureCode.Forbidden).WithError(e.Message);
            }
        }

        public Result<PagedResult<TourDto>> GetPagedByAuthorId(int authorId, int page, int pageSize)
        {
            var result = _tourRepository.GetPagedByAuthorId(authorId, page, pageSize);
            return MapToDto(result);
        }
    }
}
