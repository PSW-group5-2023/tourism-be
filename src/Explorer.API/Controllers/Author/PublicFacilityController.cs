using Microsoft.AspNetCore.Authorization;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.UseCases.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Explorer.Tours.Core.UseCases;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/publicFacility")]
    public class PublicFacilityController : BaseApiController
    {
        private readonly IPublicFacilityService _publicFacilityService;

        public PublicFacilityController(IPublicFacilityService publicFacilityService)
        {
            _publicFacilityService = publicFacilityService;
        }

        [HttpGet]
        public ActionResult<PagedResult<PublicFacilityDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _publicFacilityService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<PublicFacilityDto> Create([FromBody] PublicFacilityDto facility)
        {
            var result = _publicFacilityService.Create(facility);
            return CreateResponse(result);
        }
        [HttpPut("{tourId}/{status}")]
        public ActionResult<PublicFacilityDto> ChangeStatus(int facilityId, String status)
        {
            var result = _publicFacilityService.ChangeStatus(facilityId, status);
            return CreateResponse(result);
        }

        [HttpGet("{status}")]
        public ActionResult<PagedResult<PublicFacilityDto>> GetByStatus(String status)
        {
            var result = _publicFacilityService.GetByStatus(status);
            return CreateResponse(result);
        }


    }
}
