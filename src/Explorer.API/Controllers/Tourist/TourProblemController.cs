﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.Problem;
using Explorer.Tours.API.Public.Problem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/tourProblem")]
    public class TourProblemController : BaseApiController
    {
        private readonly ITourProblemService _problemService;

        public TourProblemController(ITourProblemService problemService)
        {
            _problemService = problemService;
        }

        [HttpPost]
        public ActionResult<TourProblemDto> Create([FromBody] TourProblemDto tourProblem)
        {
            var result = _problemService.Create(tourProblem);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<TourProblemDto> Update([FromBody] TourProblemDto tourProblem)
        {
            var result = _problemService.Update(tourProblem);
            return CreateResponse(result);
        }

        [HttpGet("{touristId:long}")]
        public ActionResult<PagedResult<TourProblemDto>> GetByTouristId(long touristId)
        {
            var result = _problemService.GetByTouristId(touristId);
            _problemService.FindNames(result.Value);
            return CreateResponse(result);
        }

        [HttpGet("messages/{userId:long}")]
        public ActionResult<PagedResult<TourProblemMessageDto>> GetUnreadMessages(long userId)
        {
            var result = _problemService.GetUnreadMessages(userId);
            return CreateResponse(result);
        }
    }
}