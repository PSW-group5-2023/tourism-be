using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Public;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "guestOrTouristPolicy")]
    [Route("api/tourist/inventory")]
    public class InventoryController : BaseApiController
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<InventoryDto> Get(int id)
        {
            var result = _inventoryService.Get(id);
            return CreateResponse(result);
        }

        [HttpPut]
        public ActionResult<InventoryDto> AddAchievementToInventory([FromQuery] int achievementId)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _inventoryService.AddAchievementToInventory(Convert.ToInt32(userId.Value), achievementId);
            return CreateResponse(result);
        }

        [HttpPut("craft")]
        public ActionResult<InventoryDto> AddComplexAchievementToInventory([FromBody] List<int> requiredAchievements)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _inventoryService.AddComplexAchievementToInventory(Convert.ToInt32(userId.Value), requiredAchievements);
            return CreateResponse(result);
        }
        [HttpGet("user/mobile")]
        public ActionResult<InventoryDto> GetByUserId() 
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result= _inventoryService.GetByUserId(Convert.ToInt32(userId.Value));
            return CreateResponse(result);
        }

    }
}
