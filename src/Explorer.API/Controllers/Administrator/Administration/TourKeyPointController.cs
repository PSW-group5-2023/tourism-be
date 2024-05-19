using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Explorer.API.Controllers.Administrator.Administration
{
    [Authorize(Policy = "administratorPolicy")]
    [Route("api/administration/tourKeyPoint")]
    public class TourKeyPointController : BaseApiController
    {
        private readonly ICheckpointService _checkpointService;
        private readonly IPublicCheckpointService _publicCheckpointService;

        public TourKeyPointController(ICheckpointService checkpointService, IPublicCheckpointService publicCheckpointService)
        {
            _checkpointService = checkpointService;
            _publicCheckpointService = publicCheckpointService;
        }

        [HttpGet]
        public ActionResult<PagedResult<CheckpointDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _checkpointService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("tour/{tourId:int}")]
        public ActionResult<PagedResult<CheckpointDto>> GetByTourId(int tourId)
        {
            var result = _checkpointService.GetByTourId(tourId);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<CheckpointDto> Get(int id)
        {
            var result = _checkpointService.Get(id);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CheckpointDto> Update([FromBody] CheckpointDto tourKeyPoint)
        {
            var result = _checkpointService.Update(tourKeyPoint);
            return CreateResponse(result);
        }

        [HttpGet("public")]
        public ActionResult<PagedResult<PublicCheckpointDto>> GetAllPublic([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _publicCheckpointService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPut("public/{tourId}/{status}")]
        public ActionResult<PublicCheckpointDto> ChangeStatus(int tourId, string status)
        {
            var result = _publicCheckpointService.ChangeStatus(tourId, status);
            return CreateResponse(result);
        }

        [HttpGet("public/{status}")]
        public ActionResult<List<PublicCheckpointDto>> GetByStatus(string status)
        {
            var result = _publicCheckpointService.GetByStatus(status);
            return CreateResponse(result);
        }

    }
}
