using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class JoinRequestService : CrudService<JoinRequestDto, JoinRequest>, IJoinRequestService
    {
        private readonly IJoinRequestRepository _requestRepository;

        public JoinRequestService(ICrudRepository<JoinRequest> repository, IMapper mapper, IJoinRequestRepository requestrepository) : base(repository, mapper) {

            _requestRepository = requestrepository;
        }

        public Result<string> CheckStatusOfRequest(long touristId, long clubId)
        {
            return _requestRepository.CheckStatusOfRequest(touristId, clubId);
        }

        public Result<List<JoinRequestDto>> FindRequests(long ownerId)
        {
            List<JoinRequest> requests = _requestRepository.FindRequestsForOwner(ownerId);

            List<JoinRequestDto> dtoList = new List<JoinRequestDto>();

            foreach (JoinRequest request in requests)
            {
                JoinRequestDto dto = new JoinRequestDto
                {
                    Id = request.Id,
                    ClubId = request.ClubId,
                    UserId = request.UserId,
                    RequestStatus = request.RequestStatus,
                    RequestDirection = request.RequestDirection
                };
                dtoList.Add(dto);
            }

            return dtoList;
        }
    }
}
