using Explorer.Tours.Core.Domain.Problem;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourProblemRepository : ITourProblemRepository
    {
        private readonly ToursContext _dbContext;

        public TourProblemRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<TourProblem> GetByTouristId(long touristId)
        {
            var tourProblems = _dbContext.TourProblems.Where(x => x.TouristId == touristId).ToList();
            return tourProblems;
        }

        public List<TourProblem> GetByTourId(long tourId)
        {
            var tourProblems = _dbContext.TourProblems.Where(x => x.TourId == tourId).ToList();
            return tourProblems;
        }

        public TourProblem GiveDeadline(DateTime deadline, long tourProblemId)
        {
            var tourProblem=_dbContext.TourProblems.First(tp=>tp.Id==tourProblemId);
            tourProblem.GiveDeadline(deadline);
            _dbContext.Update(tourProblem);
            _dbContext.SaveChanges();
            return tourProblem;
        }

        public TourProblem PunishAuthor(string authorUsername, long tourId, long tourProblemId)
        {
            var tourProblem = _dbContext.TourProblems.First(tp => tp.Id == tourProblemId);
            tourProblem.CloseProblem();
            _dbContext.Update(tourProblem);
            _dbContext.SaveChanges();
            return tourProblem;
        }
    }
}
