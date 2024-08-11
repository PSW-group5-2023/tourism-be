using Explorer.Tours.Core.Domain.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IPublicCheckpointRepository
    {
        PublicCheckpoint GetById(long id);
        PublicCheckpoint Update(PublicCheckpoint newCheckpoint);
        List<PublicCheckpoint> GetByStatus(PublicCheckpointStatus status);
    }
}
