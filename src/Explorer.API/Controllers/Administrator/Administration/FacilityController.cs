using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Facility;
using Explorer.Tours.API.Public.Facility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Administrator.Administration
{

    [Authorize(Policy = "administratorPolicy")]
    [Route("api/administration/facilities")]
    public class FacilityController : BaseApiController
    {
        private readonly IFacilityService _facilityService;

        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        [HttpGet]
        public ActionResult<PagedResult<FacilityDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _facilityService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<FacilityDto> Get(int id)
        {
            var result = _facilityService.Get(id);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<FacilityDto> Create([FromBody] FacilityDto facility)
        {
            var result = _facilityService.Create(facility);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<FacilityDto> Update([FromBody] FacilityDto facility)
        {
            var result = _facilityService.Update(facility);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _facilityService.Delete(id);
            return CreateResponse(result);
        }
    }
}

