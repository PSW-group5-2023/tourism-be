using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Administrator.Administration
{
    [Authorize(Policy = "administratorPolicy")]
    [Route("api/administration/userInformation")]
    public class UserInformationController:BaseApiController
    {
        private readonly IUserInformationService _userInformationService;

        public UserInformationController(IUserInformationService userInformationService)
        {
            _userInformationService = userInformationService;
        }
        [HttpGet]   
        public ActionResult<PagedResult<UserInformationDto>> GetAll()
        {
            var result = _userInformationService.GetUserInformation();
            return CreateResponse(result);
        }
    }
}
