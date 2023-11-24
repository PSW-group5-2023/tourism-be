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

        public ShoppingCartController(IBoughtItemService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
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
        public ActionResult<BoughtItemDto> AddToCart(List<BoughtItemDto> items)
        {
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


    }
}
