using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Dtos.Tourist;
using Explorer.Encounters.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/encounter")]
    public class EncounterController : BaseApiController
    {
        private readonly IEncounterService _encounterService;
        private readonly IQuestionService _questionService;

        public EncounterController(IEncounterService encounterService, IQuestionService questionService)
        {
            _encounterService = encounterService;
            _questionService = questionService;
        }

        [HttpGet("public")]
        public ActionResult<PagedResult<EncounterDto>> GetAllPublic()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.GetPublicPagedForTourist(long.Parse(userId.Value), 0, 0);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<EncounterDto> Create([FromBody] EncounterDto encounterDto)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.CreateForTourist(encounterDto, long.Parse(userId.Value));
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<EncounterDto> Update([FromBody] EncounterDto encounterDto)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.UpdateForTourist(encounterDto, long.Parse(userId.Value));
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.DeleteIfCreator(id, long.Parse(userId.Value));
            return CreateResponse(result);
        }

        [HttpGet("checkpoints")]
        public ActionResult<PagedResult<EncounterDto>> GetAllByCheckpointIds([FromQuery] List<long> checkpointIds)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.GetPagedByCheckpointIdsForTourist(checkpointIds, 0, 0, long.Parse(userId.Value));
            return CreateResponse(result);
        }

        [HttpPut("complete/{encounterId:int}")]
        public ActionResult<EncounterExecutionDto> Complete(int encounterId)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.Complete(long.Parse(userId.Value), encounterId);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpPut("complete-quiz/{encounterId:int}")]
        public ActionResult<EncounterExecutionDto> CompleteQuiz(int encounterId, [FromBody] List<SubmittedAnswerDto> answers)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.CompleteQuiz(long.Parse(userId.Value), encounterId, answers);
            return CreateResponse(result);
        }
        [AllowAnonymous]
        [HttpPost("start/{encounterId:long}")]
        public ActionResult<EncounterExecutionDto> StartEncounter(long encounterId)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.StartEncounter(encounterId, long.Parse(userId.Value));
            return CreateResponse(result);
        }

        [HttpGet("{id:long}")]
        public ActionResult<EncounterDto> Get(long id)
        {
            var result = _encounterService.Get(id);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpGet("forTourist/{checkpointId:int}")]
        public ActionResult<EncounterModuleQuizAchievementMobileDto> GetByCheckpointTourist(int checkpointId)
        {
            var result= _questionService.GetQuestionsByCheckpointId(checkpointId);
            return CreateResponse(result);
        }
    }
}
