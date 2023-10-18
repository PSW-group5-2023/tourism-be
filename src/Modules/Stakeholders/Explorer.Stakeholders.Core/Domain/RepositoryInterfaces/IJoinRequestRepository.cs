using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface IJoinRequestRepository
    {
        List<JoinRequest> FindRequestsForOwner(long ownerId);

        public string CheckStatusOfRequest(long touristId, long clubId); // used to see if user has already sent a request or no

        PagedResult<ClubMemberDto> GetClubMembers(long clubId, int pageIndex, int pageSize);

        PagedResult<ClubMemberDto> GetInvitableUsers(long clubId,int pageIndex, int pageSize);
        
        long KickMember(long clubId, long userId);
    }
}
