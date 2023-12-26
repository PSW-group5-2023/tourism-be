using Explorer.Tours.Core.Domain.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IInternalPositionSimulatorRepository
    {
        PositionSimulator GetByTouristId(long touristId);
    }
}
