﻿using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
        [Authorize(Policy = "authorPolicy")]
        [Route("api/author/blog")]
        public class BlogController : BaseApiController
        {
            private readonly IBlogService _blogService;

            public BlogController(IBlogService blogService)
            {
                _blogService = blogService;
            }

            [HttpPost]
            public ActionResult<BlogDto> Create([FromBody] BlogDto blog)
            {
                var result = _blogService.Create(blog);

                return CreateResponse(result);

            }
        }
    


}
