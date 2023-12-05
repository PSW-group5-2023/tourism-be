using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/sales")]
    public class SalesController : BaseApiController
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpPost]
        public ActionResult<SalesDto> Create([FromBody] SalesDto salesDto)
        {
            var result = _salesService.Create(salesDto);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<SalesDto> Update([FromBody] SalesDto salesDto)
        {
            var result = _salesService.Update(salesDto);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _salesService.Delete(id);
            return CreateResponse(result);
        }
    }
}
