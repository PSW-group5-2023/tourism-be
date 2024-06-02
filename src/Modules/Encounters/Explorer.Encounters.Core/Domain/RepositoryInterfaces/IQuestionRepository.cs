using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.Core.Domain.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.Core.Domain.RepositoryInterfaces
{
    public interface IQuestionRepository : ICrudRepository<Question>
    {
        PagedResult<Question> GetAllByEncounterId(long encounterId, int page, int pageSize);
    }
}
