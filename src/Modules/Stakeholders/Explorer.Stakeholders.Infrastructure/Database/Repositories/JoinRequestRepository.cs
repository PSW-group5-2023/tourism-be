using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;
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

        public PagedResult<ClubMemberDto> GetClubMembers(long clubId,int pageIndex, int pageSize)
        {
            var memberIds = _dbContext.JoinRequests.Where(x => x.ClubId == clubId && x.RequestStatus == "accepted").Select(x => x.UserId).ToList();
            var task = _dbContext.Users.Where(x => memberIds.Contains(x.Id)).Select(x => new ClubMemberDto { Id = x.Id, Username = x.Username }).GetPaged(pageIndex,pageSize);
            task.Wait();
            return task.Result;
        }

        public PagedResult<ClubMemberDto> GetInvitableUsers(long clubId,int pageIndex, int pageSize)
        {
            var clubMembers = _dbContext.JoinRequests.Where(x => x.ClubId == clubId && (x.RequestStatus == "pending" || x.RequestStatus == "accepted")).Select(x => x.UserId).ToList();
            var task = _dbContext.Users.Where(x => !clubMembers.Contains(x.Id) && x.Role == UserRole.Tourist).Select(x => new ClubMemberDto { Id = x.Id, Username = x.Username }).GetPaged(pageIndex,pageSize);
            task.Wait();
            return task.Result;
            
        }

        public long KickMember(long clubId,long userId)
        {
            var user = _dbContext.JoinRequests.Where(x => x.ClubId == clubId && x.UserId == userId).FirstOrDefault();
            typeof(JoinRequest).GetProperty("RequestStatus").SetValue(user, "declined");

            try
            {
                _dbContext.JoinRequests.Update(user);
                _dbContext.SaveChanges();

                return userId;
            }
            catch (DbUpdateException e)
            {
                throw new KeyNotFoundException(e.Message);
            }


        }

    }
}
