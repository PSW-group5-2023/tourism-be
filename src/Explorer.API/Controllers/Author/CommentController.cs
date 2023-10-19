using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.BuildingBlocks.Core.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    //[Authorize(Policy = "authorPolicy")]
    [Route("api/author/comment")]
    public class CommentController : BaseApiController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public ActionResult<PagedResult<CommentDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _commentService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<CommentDto> Get(int id)
        {
            var result = _commentService.Get(id);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<CommentDto> Create([FromBody] CommentDto commentDto)
        {
            var result = _commentService.Create(commentDto);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CommentDto> Update([FromBody] CommentDto commentDto)
        {
            var result = _commentService.Update(commentDto);
            return CreateResponse(result);
        }
    }
}
