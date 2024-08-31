using Explorer.Tours.Core.Domain.Facilities;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly ToursContext _dbContext;

        public FacilityRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Facility GetById(int id)
        {
            var facility = _dbContext.Facilities.FirstOrDefault(x => x.Id == id);
            return facility;
        }

        public Facility Update(Facility newFacility)
        {
            var facility = _dbContext.Facilities.FirstOrDefault(x => x.Id == newFacility.Id);
            facility = newFacility;
            _dbContext.SaveChanges();
            return facility;
        }
    }
}
