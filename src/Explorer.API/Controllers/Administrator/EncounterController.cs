﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Administrator
{
    [Authorize(Policy = "administratorPolicy")]
    [Route("api/administrator/encounter")]
    public class EncounterController : BaseApiController
    {
        private readonly IEncounterService _encounterService;

        public EncounterController(IEncounterService encounterService)
        {
            _encounterService = encounterService;
        }

        [HttpGet]
        public ActionResult<PagedResult<EncounterDto>> GetPaged([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _encounterService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<EncounterDto> Create([FromBody] EncounterDto encounterDto)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.CreateForAdministrator(encounterDto, long.Parse(userId.Value));
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<EncounterDto> Update([FromBody] EncounterDto encounterDto)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.UpdateForAdministrator(encounterDto, long.Parse(userId.Value));
            return CreateResponse(result);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = _encounterService.Delete(id);
            return CreateResponse(result);
        }

        [HttpPut("activate/{id:int}")]
        public ActionResult<EncounterDto> Activate(int id)
        {
            var result = _encounterService.ApproveTouristMadeEncounter(id);
            return CreateResponse(result);
        }

        [HttpPut("archive/{id:int}")]
        public ActionResult<EncounterDto> Archive(int id)
        {
            var result = _encounterService.ArchiveTouristMadeEncounter(id);
            return CreateResponse(result);
        }

        [HttpGet("{id:long}")]
        public ActionResult<EncounterDto> Get(long id)
        {
            var result = _encounterService.Get(id);
            return CreateResponse(result);
        }
    }
}
