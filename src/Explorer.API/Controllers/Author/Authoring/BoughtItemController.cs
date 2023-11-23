using Explorer.Tours.API.Dtos.Statistics;
using Explorer.Tours.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author.Authoring
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/boughtItem")]
    public class BoughtItemController : BaseApiController
    {
        private readonly IBoughtItemService _boughtItemService;

        public BoughtItemController(IBoughtItemService boughtItemService)
        {
            _boughtItemService = boughtItemService;
        }

        [HttpGet("getMostSoldStats")]
        public ActionResult<List<TourStatisticsDto>> GetSoldToursStatistics()
        {
            var result = _boughtItemService.GetSoldToursStatistics();
            return CreateResponse(result);
        }
    }
}
