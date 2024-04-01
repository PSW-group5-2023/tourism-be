using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.Core.Domain.Sessions;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IPositionSimulatorRepository : ICrudRepository<PositionSimulator>
    {
        PositionSimulator GetByTouristId(long touristId);
    }
}
