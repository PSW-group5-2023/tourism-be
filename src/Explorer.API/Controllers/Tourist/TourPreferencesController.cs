using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.UseCases.Administration;
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

        [HttpGet]
        public ActionResult<TourPreferencesDto> GetByUserId()
        {
            var userId = User.PersonId();
            var result = _preferencesService.GetByUserId(userId);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<TourPreferencesDto> Create([FromBody] TourPreferencesDto preferencesDto) 
        {
            if(User != null)
            {
                preferencesDto.UserId = User.PersonId();
            }
            
            var result = _preferencesService.Create(preferencesDto);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _preferencesService.Delete(id);
            return CreateResponse(result);
        }
    }
}
