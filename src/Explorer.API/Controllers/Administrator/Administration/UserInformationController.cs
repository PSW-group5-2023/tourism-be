using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.API.Dtos;
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
        private readonly IPersonInformationService _personInformationService;
        private readonly IUserActivityService _userActivityService;

        public UserInformationController(IUserInformationService userInformationService, IPersonInformationService personInformationService, IUserActivityService userActivityService)
        {
            _userInformationService = userInformationService;
            _personInformationService = personInformationService;
            _userActivityService = userActivityService;
        }


        [HttpGet]
        public ActionResult<PagedResult<UserInformationDto>> GetPaged([FromQuery] int page, [FromQuery] int pageSize)
        {
            var userResult = _userInformationService.GetPaged(page, pageSize);
            var personResult = _personInformationService.GetPaged(page, pageSize);
            _userInformationService.Join(userResult, personResult);

            return CreateResponse(userResult);
        }

        [HttpPut]
        public ActionResult<UserDto> Update(UserDto user)
        {
            var result = _userActivityService.Update(_userActivityService.Block(user).Value);
            return CreateResponse(result);
        }
    }
}
