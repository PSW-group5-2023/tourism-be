using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Authoring;
using Explorer.Tours.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/tour")]
    public class TourController : BaseApiController
    {
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<PagedResult<TourDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _tourService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public ActionResult<TourDto> Get(int id)
        {
            var result = _tourService.Get(id);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<TourDto> CreateCampaign([FromBody] CampaignDto campaignDto)
        {
            var result = _tourService.CreateCampaign(campaignDto.Tours, campaignDto.Name, campaignDto.Description, campaignDto.TouristId);
            return CreateResponse(result);
        }

        [HttpGet("search/{name}/{tags}")]
        public ActionResult<PagedResult<TourDto>> Search([FromQuery] int page, [FromQuery] int pageSize, [FromRoute] string name, [FromRoute] string[] tags)
        {
            var result = _tourService.GetPagedForSearch(name,  tags, page, pageSize);
            return CreateResponse(result);
        }
    }
}
