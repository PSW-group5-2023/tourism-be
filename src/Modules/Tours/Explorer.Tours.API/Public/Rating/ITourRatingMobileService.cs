using Explorer.Tours.API.Dtos.Rating;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Rating
{
    public interface ITourRatingMobileService
    {
        Result<TourRatingMobileDto> Create(TourRatingMobileDto rating);
    }
}
