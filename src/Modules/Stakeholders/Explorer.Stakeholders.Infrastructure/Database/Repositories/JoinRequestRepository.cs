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


        public List<JoinRequest> FindRequestsForOwner(long ownerId)
        {

            List<Club> clubs = _dbContext.Clubs.Where(c => c.TouristId == ownerId).ToList();
            
            

            List<JoinRequest> requests = _dbContext.JoinRequests.ToList().Where(jr => clubs.Any(c => c.Id == jr.ClubId)).ToList().
                Where(jr => jr.RequestStatus == "pending" && jr.RequestDirection).ToList();   //RequestDirection is true if tourist sent request to the owner

            return requests;
        }

        public string CheckStatusOfRequest(long touristId, long clubId)
        {
            foreach (JoinRequest request in _dbContext.JoinRequests)
            {
                if (request.UserId == touristId && request.ClubId == clubId)
                {
                    return request.RequestStatus;
                }
            }
            return string.Empty;
        }

    }
}
