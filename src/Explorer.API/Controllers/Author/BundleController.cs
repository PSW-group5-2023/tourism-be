using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Core.UseCases;
using Explorer.BuildingBlocks.Core.UseCases;
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
        public ActionResult<PagedResult<BundleDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _bundleService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<BundleDto> Get(int id)
        {
            var result = _bundleService.Get(id);
            return CreateResponse(result);
        }

        [HttpGet("authorBundles/{id:int}")]
        public ActionResult<PagedResult<BundleDto>> GetByAuthorId([FromQuery] int page, [FromQuery] int pageSize,int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult<BundleDto> Create([FromBody] BundleDto bundle)
        {
            var result = _bundleService.Create(bundle);
            return CreateResponse(result);
        }

        [HttpPut]
        public ActionResult<List<BundleDto>> Update([FromBody] BundleDto bundle)
        {
            var result = _bundleService.Update(bundle);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _bundleService.Delete(id);
            return CreateResponse(result);
        }

        [HttpPut("updateBundleStatus")]
        public ActionResult<BundleDto> UpdateStatus([FromBody] BundleDto bundle)
        {
            var result = _bundleService.Update(bundle);
            return CreateResponse(result);
        }

        [HttpPut("archiveBundle")]
        public ActionResult<List<BundleDto>> ArchiveBundle([FromBody] BundleDto bundle)
        {
            var result = _bundleService.Update(bundle);
            return CreateResponse(result);
        }
    }
}
