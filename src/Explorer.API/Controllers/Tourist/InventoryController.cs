using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Public;
using Explorer.BuildingBlocks.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
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

        [AllowAnonymous]
        [HttpPut]
        public ActionResult<InventoryDto> AddAchievementToInventory([FromBody] InventoryDto inventory, [FromQuery] int achievementId)
        {
            var result = _inventoryService.AddAchievementToInventory(inventory, achievementId);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpPut("craft")]
        public ActionResult<InventoryDto> AddComplexAchievementToInventory([FromBody] InventoryDto inventory, [FromQuery] List<int> requiredAchievements)
        {
            var result = _inventoryService.AddComplexAchievementToInventory(inventory, requiredAchievements);
            return CreateResponse(result);
        }
        [AllowAnonymous]
        [HttpGet("user/mobile")]
        public ActionResult<InventoryDto> GetByUserId() 
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            if (userId == null || string.IsNullOrEmpty(userId.Value))
            {
                return StatusCode(400, "User ID claim not found.");
            }
            var result= _inventoryService.GetByUserId(Convert.ToInt32(userId.Value));
            return CreateResponse(result);
        }

    }
}
