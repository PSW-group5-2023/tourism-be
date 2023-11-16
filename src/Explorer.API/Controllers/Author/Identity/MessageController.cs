using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author.Identity
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/messages")]
    public class MessageController : BaseApiController
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public ActionResult<MessageDto> Create([FromBody] MessageDto messageDto)
        {
             var result = _messageService.Create(messageDto);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<PagedResult<MessageDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize, [FromBody] long id)
        {
            var result = _messageService.GetMessagesByUserId(page, pageSize, id);
            return CreateResponse(result);
        }
    }
}
