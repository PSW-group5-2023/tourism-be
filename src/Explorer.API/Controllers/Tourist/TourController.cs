using Explorer.Blog.API.Dtos;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Authoring;
using Explorer.Tours.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/tour")]
    public class TourController : BaseApiController
    {
        private readonly ITourService _tourService;
        private readonly IRecommenderService _recommenderService;

        public TourController(ITourService tourService, IRecommenderService recommenderService)
        {
            _tourService = tourService;
            _recommenderService = recommenderService;
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


        [HttpGet("recommended/{userId:int}")]
        public ActionResult<PagedResult<TourDto>> GetRecommendedToursForTourist([FromQuery] int page, [FromQuery] int pageSize, [FromRoute] int userId)
        {
            var result = _recommenderService.GetRecommendedToursByLocation(userId, page, pageSize);
            return CreateResponse(result);
        }


        [HttpGet("location/{lat}/{lon}/{radius}/{touristId}")]
        public ActionResult<PagedResult<TourDto>> SearchByLocation([FromQuery] int page, [FromQuery] int pageSize, [FromRoute] double lat, [FromRoute] double lon, [FromRoute] double radius, [FromRoute] int touristId)
        {
            var result = _tourService.GetPagedForSearchByLocation(page, pageSize, lat, lon, radius, touristId);
            return CreateResponse(result);
        }
    }
}
