using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ITourKeyPointsRepository
    {
        List<TourKeyPoint> GetByTourId(long tourId);
        TourKeyPoint GetById(int id);
        TourKeyPoint Update(TourKeyPoint keyPoint);

        List<PublicTourKeyPoints> GetByStatus(PublicTourKeyPoints.PublicTourKeyPointStatus status);
    }
}
