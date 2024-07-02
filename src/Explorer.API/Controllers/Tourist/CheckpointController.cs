﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/tourKeyPoint")]
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

        [HttpGet("public")]
        public ActionResult<List<PublicCheckpointDto>> GetAllPublic()
        {
            var result = _publicCheckpointService.GetByStatus("Approved");
            return CreateResponse(result);
        }
    }
}