using Explorer.BuildingBlocks.Core.UseCases;
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

        private IShoppingCartService shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public ActionResult<ShoppingCartDto> GetByUserId(long userId)
        {
            return CreateResponse(shoppingCartService.GetByUserId(userId));
        }

        [HttpPut("addToCart")]
        public ActionResult<ShoppingCartDto> AddToCart(long userId,long tourId)
        {
            return CreateResponse(shoppingCartService.AddToCart(userId, tourId));
        }

        [HttpDelete("clearCart")]
        public ActionResult ClearCart(long userId)
        {
            return CreateResponse(shoppingCartService.ClearCart(userId));
        }

        [HttpDelete("deleteCartItem")]
        public ActionResult DeleteCartItem(long userId,long itemId)
        {
            return CreateResponse(shoppingCartService.DeleteCartItem(userId, itemId));
        }

    }
}
