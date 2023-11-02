using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourKeyPointsRepository : ITourKeyPointsRepository
    {
        private readonly ToursContext _dbContext;

        public TourKeyPointsRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<TourKeyPoint> GetByTourId(int tourId)
        {
            var keyPoints = _dbContext.TourKeyPoints.Where(x => x.TourId == tourId).ToList();
            return keyPoints;
        }

    }
}
