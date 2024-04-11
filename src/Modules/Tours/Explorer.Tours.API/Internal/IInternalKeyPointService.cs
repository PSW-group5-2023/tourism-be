using Explorer.Tours.API.Dtos.Tour;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Internal
{
    public interface IInternalKeyPointService
    {
        Result<TourKeyPointDto> Get(long id);
        Result<bool> CheckIfUserIsAuthor(long authorId, long keypointId);
    }
}
