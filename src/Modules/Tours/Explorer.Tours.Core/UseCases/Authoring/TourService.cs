using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Internal;
using Explorer.Tours.API.Public.Authoring;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using Microsoft.AspNetCore.SignalR;
using System.Dynamic;
using Explorer.Tours.API.Public;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.UseCases.Authoring
{
    public class TourService : CrudService<TourDto, Tour>, ITourService, IInternalTourService
    {
        private readonly ITourRepository _tourRepository;
        private readonly ITourKeyPointService _tourKeyPointService;

        public TourService(ITourRepository repository, IMapper mapper, ITourKeyPointService tourKeyPointService) : base(repository, mapper)
        {
            _tourRepository = repository;
            _tourKeyPointService = tourKeyPointService;
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
