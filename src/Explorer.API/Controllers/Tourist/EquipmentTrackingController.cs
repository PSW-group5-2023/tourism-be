using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/equipmentTracking")]
    public class EquipmentTrackingController : BaseApiController
    {
        private readonly IEquipmentTrackingService _equipmentTrackingService;
        public EquipmentTrackingController(IEquipmentTrackingService equipmentTrackingService) 
        {
            _equipmentTrackingService = equipmentTrackingService;
        }

        [HttpGet]
        public ActionResult<PagedResult<EquipmentDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _equipmentTrackingService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }
        
        [HttpPut("{id:int}")]
        public ActionResult<EquipmentTrackingDto> Update([FromBody] EquipmentTrackingDto equipment)
        {
            var result = _equipmentTrackingService.Update(equipment);
            return CreateResponse(result);
        }
    }
}
