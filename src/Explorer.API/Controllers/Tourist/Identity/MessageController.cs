﻿using Explorer.Blog.API.Dtos;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Identity
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/messages")]
    public class MessageController : BaseApiController
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public ActionResult<CommentDto> Create([FromBody] MessageDto messageDto)
        {
            var result = _messageService.Create(messageDto);
            return CreateResponse(result);
        }

        [HttpGet]
        public ActionResult<PagedResult<MessageDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            long touristId = User.PersonId();
            var result = _messageService.GetMessagesByUserId(page, pageSize, touristId);
            return CreateResponse(result);
        }
    }
}
