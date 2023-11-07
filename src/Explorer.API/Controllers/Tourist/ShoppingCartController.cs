﻿using Explorer.BuildingBlocks.Core.UseCases;
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
        public ActionResult<BoughtItemDto> GetItems(long userId)
        {
            return CreateResponse(shoppingCartService.GetItemsByUserId(userId));
        }

        [HttpPut("addToCart")]
        public ActionResult<BoughtItemDto> AddToCart(List<BoughtItemDto> items)
        {
            return CreateResponse(shoppingCartService.Create(items));
        }

    }
}
