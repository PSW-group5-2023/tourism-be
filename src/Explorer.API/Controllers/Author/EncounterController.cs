using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/encounter")]
    public class EncounterController : BaseApiController
    {
        private readonly IEncounterService _encounterService;
        private readonly ITokenGenerator _tokenGenerator;
        public EncounterController(IEncounterService encounterService, ITokenGenerator tokenGenerator)
        {
            _encounterService = encounterService;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        public ActionResult<EncounterDto> Create([FromBody] EncounterDto encounterDto)
        {
            var userId = _tokenGenerator.GetUserIdFromToken(Request.Headers["Authorization"][0].Substring("Bearer ".Length).Trim());
            var result = _encounterService.CreateForAuthor(encounterDto, userId);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var userId = _tokenGenerator.GetUserIdFromToken(Request.Headers["Authorization"][0].Substring("Bearer ".Length).Trim());
            var result = _encounterService.DeleteIfCreator(id, userId);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<EncounterDto> Update([FromBody] EncounterDto encounterDto)
        {
            var userId = _tokenGenerator.GetUserIdFromToken(Request.Headers["Authorization"][0].Substring("Bearer ".Length).Trim());
            var result = _encounterService.UpdateForAuthor(encounterDto, userId);
            return CreateResponse(result);
        }

        [HttpGet("keypoints")]
        public ActionResult GetAllByKeyPointIds([FromQuery] List<long> keyPointIds)
        {
            var userId = _tokenGenerator.GetUserIdFromToken(Request.Headers["Authorization"][0].Substring("Bearer ".Length).Trim());
            var result = _encounterService.GetPagedByKeyPointIds(keyPointIds, 0, 0);
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
