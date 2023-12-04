using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Payments.Core.Domain;
using Explorer.Tours.API.Public.Administration;

namespace Explorer.Payments.Core.UseCases;

public class CouponService : CrudService<CouponDto, Coupon>, ICouponService
{
    public CouponService(ICrudRepository<Coupon> repository, IMapper mapper) : base(repository, mapper) { }
}