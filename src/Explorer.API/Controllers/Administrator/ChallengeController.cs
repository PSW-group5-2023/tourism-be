using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Explorer.Tours.API.Dtos;

namespace Explorer.API.Controllers.Administrator
{
    [Authorize(Policy = "administratorPolicy")]
    [Route("api/administrator/challenge")]
    public class ChallengeController : BaseApiController
    {
        private readonly IChallengeService _challengeService;
        private readonly ILocationChallengeService _locationChallengeService;

        public ChallengeController(IChallengeService challengeService, ILocationChallengeService locationChallengeService)
        {
            _challengeService = challengeService;
            _locationChallengeService = locationChallengeService;
        }

        [HttpGet]
        public ActionResult<PagedResult<ChallengeDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _challengeService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<ChallengeDto> Create([FromBody] ChallengeDto challengeDto)
        {
            var result = _challengeService.Create(challengeDto);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ChallengeDto> Update([FromBody] ChallengeDto challengeDto)
        {
            var result = _challengeService.Update(challengeDto);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _challengeService.Delete(id);
            return CreateResponse(result);
        }

        [HttpGet("location")]
        public ActionResult<PagedResult<LocationChallengeDto>> GetAllLocationChallenge([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _locationChallengeService.GetPaged(page,pageSize);
            return CreateResponse(result);
        }

        [HttpPost("location")]
        public ActionResult<LocationChallengeDto> CreateLocationChallange([FromBody] LocationChallengeDto challangeDto)
        {
            var result = _locationChallengeService.Create(challangeDto);
            return CreateResponse(result);
        }

        [HttpPut("location/{id:int}")]
        public ActionResult<ChallengeDto> UpdateLocationChallenge([FromBody] LocationChallengeDto challengeDto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("location/{id:int}")]
        public ActionResult DeleteLocationChallenge(int id)
        {
            throw new NotImplementedException();
        }
    }
}
