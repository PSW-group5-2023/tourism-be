using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Tours.API.Dtos;
using FluentResults;

namespace Explorer.Tours.API.Public
{
    public interface ITourKeyPointService
    {
        Result<TourKeyPointDto> Create(TourKeyPointDto tourKeyPoint);
        Result<TourKeyPointDto> Update(TourKeyPointDto tourKeyPoint);
        Result Delete(int id);
    }
}
