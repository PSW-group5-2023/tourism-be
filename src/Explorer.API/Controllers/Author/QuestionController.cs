using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy ="authorPolicy")]
    [Route("api/author/questions")]
    public class QuestionController : BaseApiController
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public ActionResult<QuestionDto> Create([FromBody] QuestionDto questionDto)
        {
            var result = _questionService.Create(questionDto);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<QuestionDto> Update([FromBody] QuestionDto questionDto)
        {
            var result = _questionService.Update(questionDto);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _questionService.Delete(id);
            return CreateResponse(result);
        }
    }
}
