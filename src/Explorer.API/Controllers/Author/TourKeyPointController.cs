using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.UseCases.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/tourKeyPoint")]
    public class TourKeyPointController : BaseApiController
    {
        private readonly ITourKeyPointService _tourKeyPointService;

        public TourKeyPointController(ITourKeyPointService tourKeyPointService)
        {
            _tourKeyPointService = tourKeyPointService;
        }


        [HttpPost]
        public ActionResult<TourKeyPointDto> Create([FromBody] TourKeyPointDto tourKeyPoint)
        {
            var result = _tourKeyPointService.Create(tourKeyPoint);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<TourKeyPointDto> Update([FromBody] TourKeyPointDto tourKeyPoint)
        {
            var result = _tourKeyPointService.Update(tourKeyPoint);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _tourKeyPointService.Delete(id);
            return CreateResponse(result);

        }
    }
}
