using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/tourKeyPoint")]
    public class CheckpointController : BaseApiController
    {
        private readonly ICheckpointService _checkpointService;
        private readonly IPublicCheckpointService _publicCheckpointService;

        public CheckpointController(ICheckpointService checkpointService, IPublicCheckpointService publicCheckpointService)
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

        [HttpPost]
        public ActionResult<CheckpointDto> Create([FromBody] CheckpointDto tourKeyPoint)
        {
            var result = _checkpointService.Create(tourKeyPoint);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CheckpointDto> Update([FromBody] CheckpointDto tourKeyPoint)
        {
            var result = _checkpointService.Update(tourKeyPoint);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _checkpointService.Delete(id);
            return CreateResponse(result);

        }



        [HttpGet("public")]
        public ActionResult<PagedResult<PublicCheckpointDto>> GetAllPublic([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _publicCheckpointService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost("public")]
        public ActionResult<PublicCheckpointDto> CreatePublic([FromBody] PublicCheckpointDto tourKeyPoint)
        {
            var result = _publicCheckpointService.Create(tourKeyPoint);
            return CreateResponse(result);
        }

        [HttpPut("public/{tourId}/{status}")]
        public ActionResult<PublicCheckpointDto> ChangeStatus(int tourId, String status)
        {
            var result = _publicCheckpointService.ChangeStatus(tourId, status);
            return CreateResponse(result);
        }

        [HttpGet("public/{status}")]
        public ActionResult<PagedResult<PublicCheckpointDto>> GetByStatus(String status)
        {
            var result = _publicCheckpointService.GetByStatus(status);
            return CreateResponse(result);
        }

    }
}
