using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/encounter")]
    public class EncounterController : BaseApiController
    {
        private readonly IEncounterService _encounterService;
        private readonly ITokenGenerator _tokenGenerator;

        public EncounterController(IEncounterService encounterService, ITokenGenerator tokenGenerator)
        {
            _encounterService = encounterService;
            _tokenGenerator = tokenGenerator;
        }

        [HttpGet("public")]
        public ActionResult<PagedResult<EncounterDto>> GetAllPublic([FromQuery] int page, [FromQuery] int pageSize)
        {
            var userId = _tokenGenerator.GetUserIdFromToken(Request.Headers["Authorization"][0].Substring("Bearer ".Length).Trim());
            var result = _encounterService.GetPublicPaged(userId, page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<EncounterDto> Create([FromBody] EncounterDto encounterDto)
        {
            var userId = _tokenGenerator.GetUserIdFromToken(Request.Headers["Authorization"][0].Substring("Bearer ".Length).Trim());
            var result = _encounterService.CreateForTourist(encounterDto, userId);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<EncounterDto> Update([FromBody] EncounterDto encounterDto)
        {
            var userId = _tokenGenerator.GetUserIdFromToken(Request.Headers["Authorization"][0].Substring("Bearer ".Length).Trim());
            var result = _encounterService.UpdateForTourist(encounterDto, userId);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var userId = _tokenGenerator.GetUserIdFromToken(Request.Headers["Authorization"][0].Substring("Bearer ".Length).Trim());
            var result = _encounterService.DeleteForTourist(id, userId);
            return CreateResponse(result);
        }

        [HttpGet("KeyPoints")]
        public ActionResult GetAllByKeyPointIds([FromQuery] List<long> keyPointIds)
        {
            var userId = _tokenGenerator.GetUserIdFromToken(Request.Headers["Authorization"][0].Substring("Bearer ".Length).Trim());
            var result = _encounterService.GetPagedByKeyPointIdsForTourist(keyPointIds, 0, 0, userId);
            return CreateResponse(result);
        }
    }
}
