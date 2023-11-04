﻿using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.UseCases.Administration;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/blog")]
    public class BlogController : BaseApiController
    {
        private readonly IBlogService _blogService;
        //private readonly ICommentService _commentService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
            //_commentService = commentService;
        }

        [HttpPost]
        public ActionResult<BlogDto> Create([FromBody] BlogDto blog)
        {
            var result = _blogService.Create(blog);
            return CreateResponse(result);
        }

        [HttpGet]
        public ActionResult<BlogDto> GetAll()
        {
            var result = _blogService.GetPaged(0,0);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<BlogDto> Get(int id)
        {
            var result = _blogService.Get(id);
            return CreateResponse(result);
        }

        [HttpPost("createComment")]
        public ActionResult<CommentDto> Create([FromBody] CommentDto commentDto)
        {
            var result = _blogService.CreateComment(commentDto);
            return CreateResponse(result);
        }

        [HttpGet("comment/{id:int}")]
        public ActionResult<CommentDto> GetComment(int id)
        {
            var result = _blogService.GetComment(id);
            return CreateResponse(result);
        }

        [HttpPut("editComment")]
        public ActionResult<CommentDto> UpdateComment([FromBody] CommentDto commentDto)
        {
            var result = _blogService.UpdateComment(commentDto);
            return CreateResponse(result);
        }

        [HttpDelete("deleteComment/{id:int}")]
        public ActionResult DeleteComment(int id)
        {
            var result = _blogService.DeleteComment(id);
            return CreateResponse(result);
        }

        [HttpGet("allComments")]
        public ActionResult<PagedResult<CommentDto>> GetAllComments([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _blogService.GetPagedComments(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("blogComments/{blogId:int}")]
        public ActionResult<List<CommentDto>> GetCommentsByBlogId(int blogId)
        {
            var result = _blogService.GetCommentsByBlogId(blogId);
            return CreateResponse(result);
        }
    }
}
