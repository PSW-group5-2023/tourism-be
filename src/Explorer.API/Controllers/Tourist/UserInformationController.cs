using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Public;
using Explorer.Achievements.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Dtos.Tourist;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;
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
        public ActionResult<UserInformationMobileDto> GetMobile()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _userInformaionService.GetMobile(Convert.ToInt32(userId.Value));
            return CreateResponse(result);
        }

        [HttpDelete]
        public ActionResult Delete() 
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result= _userInformaionService.Delete(Convert.ToInt32(userId.Value));
            return CreateResponse(result);

        }
        [HttpPut("changeAvatarImage")]
        public ActionResult<UserInformationMobileDto> ChangeAvatarImage([FromBody]string image)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _userInformaionService.ChangeAvatarImage(image, Convert.ToInt32(userId.Value));
            return CreateResponse(result);
        }
    }
}
