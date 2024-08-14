﻿using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Public;
using Explorer.Achievements.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "guestOrTouristPolicy")]
    [Route("api/tourist/userInformation")]
    public class UserInformationController:BaseApiController
    {
        private readonly IUserInformationService _userInformaionService;
        public UserInformationController(IUserInformationService userInformaionService)
        {
            _userInformaionService = userInformaionService;
        }
        [HttpGet]
        public ActionResult<UserInformationDto> GetMobile()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _userInformaionService.GetMobile(Convert.ToInt32(userId.Value));
            return CreateResponse(result);
        }
    }
}