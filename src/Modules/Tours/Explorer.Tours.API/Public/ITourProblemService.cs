using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public
{
    public interface ITourProblemService
    {
        Result<PagedResult<TourProblemDto>> GetPaged(int page, int pageSize);
        Result<TourProblemDto> Create(TourProblemDto tourProblem);
        Result<TourProblemDto> Update(TourProblemDto tourProblem);
        Result<List<TourProblemDto>> GetByTouristId(long touristId);
        Result<List<TourProblemDto>> GetByTourId(long tourId);
    }
}
