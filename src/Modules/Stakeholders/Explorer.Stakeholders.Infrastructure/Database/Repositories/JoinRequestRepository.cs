﻿using Explorer.Stakeholders.Core.Domain;
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

        public List<Club> getClubsToJoin(long userId)
        {
            var userClub = _dbContext.Clubs.FirstOrDefault(club => club.TouristId == userId);

            if (userClub == null)
            {
                var allClubs = _dbContext.Clubs.Where(club => club.TouristId != userId).ToList();

                // Zatim pronađite ClubId-jeve za koje postoji zahtev sa odgovarajućim UserId
                var clubIdsWithRequests = _dbContext.JoinRequests
                    .Where(request => request.UserId == userId)
                    .Select(request => request.ClubId)
                    .ToList();

                // Izbacite klubove sa zahtevima iz liste svih klubova
                var clubsToJoin = allClubs.Where(club => !clubIdsWithRequests.Contains(club.Id)).ToList();


                return clubsToJoin;
            }
            else
            {
                var allClubs = _dbContext.Clubs.Where(club => club.TouristId != userId).ToList();

                // Zatim pronađite ClubId-jeve za koje postoji zahtev sa odgovarajućim UserId
                var clubIdsWithRequests = _dbContext.JoinRequests
                    .Where(request => request.UserId == userId)
                    .Select(request => request.ClubId)
                    .ToList();

                // Izbacite klub vlasnika i klubove sa zahtevima iz liste svih klubova
                var clubsToJoin = allClubs.Where(club => club.Id != userClub.Id && !clubIdsWithRequests.Contains(club.Id)).ToList();

                return clubsToJoin;
            }
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