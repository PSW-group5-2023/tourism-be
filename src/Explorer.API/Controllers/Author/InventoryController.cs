using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Public;
using Explorer.Achievements.Core.UseCases;
using Explorer.BuildingBlocks.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/inventory")]
    public class InventoryController : BaseApiController
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService) 
        {
            _inventoryService = inventoryService;
        }
        [HttpPost]
        public ActionResult<InventoryDto> Create([FromBody] InventoryDto achievement)
        {
            var result = _inventoryService.Create(achievement);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<InventoryDto> Get(int id)
        {
            var result = _inventoryService.Get(id);
            return CreateResponse(result);
        }

        [HttpGet]
        public ActionResult<PagedResult<InventoryDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _inventoryService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _inventoryService.Delete(id);
            return CreateResponse(result);
        }

        [HttpPut]
        public ActionResult<InventoryDto> AddAchievementToInventory([FromBody]InventoryDto inventory, [FromQuery] int achievementId)
        {
            var result = _inventoryService.AddAchievementToInventory(inventory, achievementId);
            return CreateResponse(result);
        }

        [HttpPut("craft")]
        public ActionResult<InventoryDto> AddComplexAchievementToInventory([FromBody]InventoryDto inventory, [FromQuery] List<int> requiredAchievements)
        {
            var result = _inventoryService.AddComplexAchievementToInventory(inventory, requiredAchievements);
            return CreateResponse(result);
        }
    }
}
