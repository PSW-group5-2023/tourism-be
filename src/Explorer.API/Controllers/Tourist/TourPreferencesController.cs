using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

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

        [HttpPost]
        public ActionResult<TourPreferencesDto> Create([FromBody] TourPreferencesDto preferencesDto) 
        {
            var result = _preferencesService.Create(preferencesDto);
            return CreateResponse(result);
        }
    }
}
