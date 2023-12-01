﻿using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Route("api/author/bundle")]
    public class BundleController : BaseApiController
    {
        private readonly IBundleService _bundleService;

        public BundleController(IBundleService bundleService)
        {
            _bundleService = bundleService;
            
        }

        [HttpGet]
        public ActionResult<List<BundleDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult<BundleDto> Create([FromBody] BundleDto bundle)
        {
            //var result = _bundleService.Create(bundle);
            //return CreateResponse(result);
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult<List<BundleDto>> Update([FromBody] BundleDto bundle)
        {
            //var result = _bundleService.Update(bundle);
            //return CreateResponse(result);
            throw new NotImplementedException();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            //var result = _bundleService.Delete(id);
            //return CreateResponse(result);
            throw new NotImplementedException();
        }
    }
}
