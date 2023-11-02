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
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;


namespace Explorer.Tours.Core.UseCases
{
    public class TourProblemService : CrudService<TourProblemDto, TourProblem>, ITourProblemService
    {
        private readonly ITourProblemRepository _tourProblemRepository;

        public TourProblemService(ICrudRepository<TourProblem> repository, IMapper mapper, ITourProblemRepository tourProblemRepository) : base(repository, mapper)
        {
            _tourProblemRepository = tourProblemRepository;
        }
        public Result<List<TourProblemDto>> GetByTouristId(long touristId)
        {
            List<TourProblemDto> result = new List<TourProblemDto>();
            List<TourProblem> tourProblems = _tourProblemRepository.GetByTouristId(touristId);
            tourProblems.ForEach(t => result.Add(MapToDto(t)));
            return result;
        }
        public Result<List<TourProblemDto>> GetByTourId(long tourId)
        {
            List<TourProblemDto> result = new List<TourProblemDto>();
            List<TourProblem> tourProblems = _tourProblemRepository.GetByTourId(tourId);
            tourProblems.ForEach(t => result.Add(MapToDto(t)));
            return result;
        }
    }
}
