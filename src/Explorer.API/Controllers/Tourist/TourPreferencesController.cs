using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/tourPreferences")]
    public class TourPreferencesController : BaseApiController
    {
        private readonly ITourPreferencesService _preferencesService;
        public TourPreferencesController(ITourPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;
        }
/*
        [HttpGet("{id:int}")]
        public ActionResult<TourPreferencesDto> GetByUserId(string userId)
        {
            var result = _preferencesService.GetByUserId(userId);
            return CreateResponse(result);
        }
*/
        [HttpPost]
        public ActionResult<TourPreferencesDto> Create([FromBody] TourPreferencesDto preferencesDto) 
        {
            var result = _preferencesService.Create(preferencesDto);
            return CreateResponse(result);
        }
    }
}
