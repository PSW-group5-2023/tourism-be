using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/encounter")]
    public class EncounterController : BaseApiController
    {
        private readonly IEncounterService _encounterService;
        private readonly IEncounterExecutionService _executionService;

        public EncounterController(IEncounterService encounterService, IEncounterExecutionService executionService)
        {
            _encounterService = encounterService;
            _executionService = executionService;
        }

        [HttpGet("public")]
        public ActionResult<PagedResult<EncounterDto>> GetAllPublic()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.GetPublicPagedForTourist(long.Parse(userId.Value), 0, 0);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<EncounterDto> Create([FromBody] EncounterDto encounterDto)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.CreateForTourist(encounterDto, long.Parse(userId.Value));
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<EncounterDto> Update([FromBody] EncounterDto encounterDto)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.UpdateForTourist(encounterDto, long.Parse(userId.Value));
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.DeleteIfCreator(id, long.Parse(userId.Value));
            return CreateResponse(result);
        }

        [HttpGet("keypoints")]
        public ActionResult<PagedResult<EncounterDto>> GetAllByKeyPointIds([FromQuery] List<long> keyPointIds)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.GetPagedByKeyPointIdsForTourist(keyPointIds, 0, 0, long.Parse(userId.Value));
            return CreateResponse(result);
        }

        [HttpPut("complete/{touristId:int}/{encounterId:int}")]
        public ActionResult<EncounterExecutionDto> Complete(int touristId, int encounterId)
        {
            var result = _encounterService.Complete(touristId, encounterId);
            return CreateResponse(result);
        }

        [HttpPost("execute")]
        public ActionResult<EncounterExecutionDto> CreateEncounterExecutionSession([FromBody] EncounterExecutionDto encounterExecutionDto)
        {
            var result = _executionService.Create(encounterExecutionDto);
            return CreateResponse(result);
        }

        [HttpGet("{id:long}")]
        public ActionResult<EncounterDto> Get(long id)
        {
            var result = _encounterService.Get(id);
            return CreateResponse(result);
        }
    }
}
