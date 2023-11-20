using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/encounter")]
    public class EncounterController : BaseApiController
    {
        private readonly IEncounterService _encounterService;

        public EncounterController(IEncounterService encounterController)
        {
            _encounterService = encounterController;
        }

        [HttpGet]
        public ActionResult<PagedResult<EncounterDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _encounterService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<EncounterDto> Create([FromBody] EncounterDto encounterDto)
        {
            var result = _encounterService.Create(encounterDto);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<EncounterDto> Update([FromBody] EncounterDto encounterDto)
        {
            var result = _encounterService.Update(encounterDto);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _encounterService.Delete(id);
            return CreateResponse(result);
        }
    }
}
