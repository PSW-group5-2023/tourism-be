using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    public class JoinRequestRepository : IJoinRequestRepository
    {

        private readonly StakeholdersContext _dbContext;

        public JoinRequestRepository(StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Result<JoinRequest>> FindRequests(string username)
        {
            throw new NotImplementedException();
        }

    }
}
