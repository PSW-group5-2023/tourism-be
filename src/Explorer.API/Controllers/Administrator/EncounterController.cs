using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Administrator
{
    [Authorize(Policy = "administratorPolicy")]
    [Route("api/administrator/encounter")]
    public class EncounterController : BaseApiController
    {
        private readonly IEncounterService _encounterService;
        private readonly ITokenGenerator _tokenGenerator;

        public EncounterController(IEncounterService encounterService, ITokenGenerator tokenGenerator)
        {
            _encounterService = encounterService;
            _tokenGenerator = tokenGenerator;
        }

        [HttpGet]
        public ActionResult<PagedResult<EncounterDto>> GetPaged([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _encounterService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<EncounterDto> Create([FromBody] EncounterDto encounterDto)
        {
            var userId = _tokenGenerator.GetUserIdFromToken(Request.Headers["Authorization"][0].Substring("Bearer ".Length).Trim());
            var result = _encounterService.CreateForAdministrator(encounterDto, userId);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<EncounterDto> Update([FromBody] EncounterDto encounterDto)
        {
            var userId = _tokenGenerator.GetUserIdFromToken(Request.Headers["Authorization"][0].Substring("Bearer ".Length).Trim());
            var result = _encounterService.UpdateForAdministrator(encounterDto, userId);
            return CreateResponse(result);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = _encounterService.Delete(id);
            return CreateResponse(result);
        }

        [HttpPut("activate/{id:int}")]
        public ActionResult<EncounterDto> Activate(int id)
        {
            var result = _encounterService.ApproveTouristMadeEncounter(id);
            return CreateResponse(result);
        }

        [HttpPut("archive/{id:int}")]
        public ActionResult<EncounterDto> Archive(int id)
        {
            var result = _encounterService.ArchiveTouristMadeEncounter(id);
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
