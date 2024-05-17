using Explorer.Tours.API.Public.Tour;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/tourKeyPoint")]
    public class TouristCheckpointController : BaseApiController
    {
        private readonly ICheckpointService _checkpointService;

        public TouristCheckpointController(ICheckpointService checkpointService)
        {
            _checkpointService = checkpointService;
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _checkpointService.Delete(id);
            return CreateResponse(result);

        }
    }
}
