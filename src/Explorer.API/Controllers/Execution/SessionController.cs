﻿using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Execution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Execution
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/session")]
    public class SessionController : BaseApiController
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet("{id:long}")]
        public ActionResult<SessionDto> Get(int id)
        {
            var result = _sessionService.Get(id);
            return CreateResponse(result);
        }

        [HttpGet("getByTouristId/{id:long}")]
        public ActionResult<SessionDto> GetByTouristId(long id)
        {
            var result = _sessionService.GetByTouristId(id);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<SessionDto> Create([FromBody] SessionDto session)
        {
            var result = _sessionService.Create(session);
            return CreateResponse(result);
        }

        [HttpPut]
        public ActionResult<SessionDto> Update([FromBody] SessionDto session)
        {
            var result = _sessionService.Update(session);
            return CreateResponse(result);
        }

        [HttpGet("check/{id:long}")]
        public ActionResult<bool> Check(int id)
        {
            var result = _sessionService.ValidForTouristComment(id);
            return CreateResponse(result);
        }

        [HttpPut("completeKeyPoint/{sessionId:int}/{keyPointId:int}")]
        public ActionResult<SessionDto> CompleteKeyPoint(int sessionId, int keyPointId)
        {
            var result = _sessionService.AddCompletedKeyPoint(sessionId, keyPointId);
            return CreateResponse(result);
        }
    }
}
