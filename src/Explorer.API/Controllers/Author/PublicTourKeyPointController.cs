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
    [Route("api/publicTourKeyPoint")]
    public class PublicTourKeyPointController : BaseApiController
    {
        private readonly IPublicTourKeyPointService _publicTourKeyPointService;

        public PublicTourKeyPointController(IPublicTourKeyPointService publicTourKeyPointService)
        {
            _publicTourKeyPointService = publicTourKeyPointService;
        }

        [HttpGet]
        public ActionResult<PagedResult<PublicTourKeyPointDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _publicTourKeyPointService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<PublicTourKeyPointDto> Create([FromBody] PublicTourKeyPointDto tourKeyPoint)
        {
            var result = _publicTourKeyPointService.Create(tourKeyPoint);
            return CreateResponse(result);
        }

        [HttpPut("{tourId}/{status}")]
        public ActionResult<PublicTourKeyPointDto> ChangeStatus(int tourId, String status)
        {
            var result = _publicTourKeyPointService.ChangeStatus(tourId, status);
            return CreateResponse(result);
        }

        [HttpGet("{status}")]
        public ActionResult<PagedResult<PublicTourKeyPointDto>> GetByStatus(String status)
        {
            var result = _publicTourKeyPointService.GetByStatus(status);
            return CreateResponse(result);
        }
    }
}
