using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
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


        [HttpPost]
        public ActionResult<ClubDto> Create([FromBody] JoinRequestDto requestDto)
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
    }
}