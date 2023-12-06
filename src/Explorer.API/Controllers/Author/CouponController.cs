using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author;

[Authorize(Policy = "authorPolicy")]
[Route("api/author/coupon")]
public class CouponController : BaseApiController
{
    private readonly ICouponService _couponService;

    public CouponController(ICouponService couponService)
    {
        _couponService = couponService;
    }

    [HttpPost]
    public ActionResult<CouponDto> Create([FromBody] CouponDto equipment)
    {
        var result = _couponService.Create(equipment);
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<CouponDto> Update([FromBody] CouponDto equipment)
    {
        var result = _couponService.Update(equipment);
        return CreateResponse(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _couponService.Delete(id);
        return CreateResponse(result);
    }

    [HttpGet]
    public ActionResult<PagedResult<CouponDto>> GetAllByAuthorId([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] int authorId)
    {
        var result = _couponService.GetPagedByAuthorId(page, pageSize, authorId);
        return CreateResponse(result);
    }
}
