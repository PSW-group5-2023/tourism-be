
using Explorer.Tours.Core.Domain.Facilities;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IFacilityRepository
    {

        Facility GetById(int id);
        Facility Update(Facility newFacility);

        List<PublicFacility> GetByStatus(PublicFacility.PublicFacilityStatus status);
    }
}
