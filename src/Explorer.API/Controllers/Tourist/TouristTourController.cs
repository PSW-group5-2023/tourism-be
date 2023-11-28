using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.TouristTour;
using Explorer.Tours.API.Public.TouristTour;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/touristTour")]
    public class TouristTourController : BaseApiController
    {
        public TouristTourController(ITouristTourService touristTourService) { }


        [HttpPost]
        public ActionResult<TouristTourDto> Create([FromBody] TouristTourDto tour)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id:int}")]
        public ActionResult<TouristTourDto> Update([FromBody] TouristTourDto tour)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}")]
        public ActionResult<TouristTourDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("tourist")]
        public ActionResult<PagedResult<TouristTourDto>> GetAllByAuthorId([FromQuery] int authorId, [FromQuery] int page, [FromQuery] int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
