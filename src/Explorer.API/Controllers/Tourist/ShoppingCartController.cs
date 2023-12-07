using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/shoppingcart")]
    public class ShoppingCartController : BaseApiController
    {

        private IBoughtItemService shoppingCartService;
        private readonly IWalletService _walletService;

        public ShoppingCartController(IBoughtItemService shoppingCartService, IWalletService walletService)
        {
            this.shoppingCartService = shoppingCartService;
            _walletService = walletService;
        }

        [HttpGet]
        public ActionResult<BoughtItemDto> GetUnusedItems(long userId)
        {
            return CreateResponse(shoppingCartService.GetUnusedTours(userId));
        }

        [AllowAnonymous]
        [HttpGet("{userId:long}")]
        public ActionResult<BoughtItemDto> GetUsedItems(long userId)
        {
            return CreateResponse(shoppingCartService.GetUsedTours(userId));
        }

        [HttpPost("addToCart")]
        public ActionResult<BoughtItemDto> AddToCart([FromBody] List<BoughtItemDto> items, [FromQuery] int cost)
        {
            _walletService.SubFromBallance(items.First().UserId, cost);
            return CreateResponse(shoppingCartService.Create(items));
        }

        [HttpDelete("deleteCartItem")]
        public ActionResult DeleteCartItem(long tourId, long userId)
        {
            return CreateResponse(shoppingCartService.DeleteItem(tourId, userId));
        }

        [HttpPost("{userId:long}/{tourId:long}")]
        public ActionResult<JoinRequestDto> CheckStatus(long userId, long tourId)
        {
            var result = shoppingCartService.UpdateItem(userId, tourId);
            return CreateResponse(result);
        }

        [HttpGet("getWallet")]
        public ActionResult GetWalletByUserId([FromQuery] int userId)
        {
            return CreateResponse(_walletService.GetByUserId(userId));
        }


    }
}
