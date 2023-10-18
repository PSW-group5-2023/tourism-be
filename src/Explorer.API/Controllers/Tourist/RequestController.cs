using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/request")]
    public class RequestController : BaseApiController
    {
        private readonly IJoinRequestService _requestService;

        public RequestController(IJoinRequestService clubService)
        {
            _requestService = clubService;
        }

        [HttpGet("{id:long}")]
        public ActionResult<ClubDto> GetAllRequests(long id)
        {
            var result = _requestService.FindRequests(id);
            return CreateResponse(result);
        }

        [HttpGet("{id:long}/{id2:long}")]
        public ActionResult<ClubDto> CheckStatus(long id, long id2)
        {
            var result = _requestService.CheckStatusOfRequest(id, id2);
            return CreateResponse(result);
        }


        [HttpPost]
        public ActionResult<JoinRequestDto> Create([FromBody] JoinRequestDto requestDto)
        {
            var result = _requestService.Create(requestDto);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ClubDto> Update([FromBody] JoinRequestDto requestDto)
        {
            var result = _requestService.Update(requestDto);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _requestService.Delete(id);
            return CreateResponse(result);
        }

        [HttpGet("members")]
        public ActionResult<List<ClubMemberDto>> GetMembers(long clubId, int pageIndex, int pageSize)
        {
            return CreateResponse(_requestService.GetClubMembers(clubId, pageIndex, pageSize));
        }

        [HttpGet("invitableUsers")]
        public ActionResult<PagedResult<ClubMemberDto>> GetInvitableUsers(long clubId, int pageIndex, int pageSize)
        {
            return CreateResponse(_requestService.GetInvitableUsers(clubId, pageIndex, pageSize));
        }

        [HttpPut("kick")]
        public ActionResult<long> KickMember(long clubId, long userId)
        {
            return CreateResponse(_requestService.KickMember(clubId, userId));
        }
    }
}