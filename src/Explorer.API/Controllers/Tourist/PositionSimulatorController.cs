using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{

    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/positionSimulator")]
    public class PositionSimulatorController : BaseApiController
    {
        private readonly IPositionSimulatorService _positionSimulatorService;

        public PositionSimulatorController(IPositionSimulatorService positionSimulatorService)
        {
            _positionSimulatorService = positionSimulatorService;
        }

        [HttpPost]
        public ActionResult<PositionSimulatorDto> Create([FromBody] PositionSimulatorDto positionSimulatorDto)
        {
            var result = _positionSimulatorService.Create(positionSimulatorDto);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<PositionSimulatorDto> Update([FromBody] PositionSimulatorDto positionSimulatorDto)
        {
            var result = _positionSimulatorService.Update(positionSimulatorDto);
            return CreateResponse(result);
        }
    }
}
