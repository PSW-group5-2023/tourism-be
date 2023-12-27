using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers;

[Route("api/users")]
public class AuthenticationController : BaseApiController
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IWalletService _walletService;

    public AuthenticationController(IAuthenticationService authenticationService, IWalletService walletService)
    {
        _authenticationService = authenticationService;
        _walletService = walletService;
    }

    [HttpPost]
    public ActionResult<AuthenticationTokensDto> RegisterTourist([FromBody] AccountRegistrationDto account)
    {
        var result = _authenticationService.RegisterTourist(account);

        WalletDto wallet = new WalletDto(result.Value.Id, 0);
        _walletService.Create(wallet);

        return CreateResponse(result);
    }

    [HttpPost("login")]
    public ActionResult<AuthenticationTokensDto> Login([FromBody] CredentialsDto credentials)
    {
        var result = _authenticationService.Login(credentials);
        return CreateResponse(result);
    }

    [HttpPost("changePasswordRequest")]
    public ActionResult<string> ChangePasswordRequest([FromQuery] string email)
    {
        try
        {
            var result = _authenticationService.ChangePasswordRequest(email);
            if (result.IsFailed)
            {
                var badRequest = new { Message = result, Success = false };
                return BadRequest(badRequest);
            }
            var response = new { Message = result, Success = true }; 

            return Ok(response);
        }
        catch (Exception ex)
        {
            var errorResponse = new { ErrorMessage = ex.Message, Success = false };
            return BadRequest(errorResponse);
        }
    }

    [HttpPost("changePassword")]
    public ActionResult<string> ChangePassword([FromBody] ChangePasswordDto changePassword)
    {
        try
        {
            var result = _authenticationService.ChangePassword(changePassword);
            var response = new { Message = result, Success = true };
            return Ok(response);
        }
        catch (Exception ex)
        {
            var errorResponse = new { ErrorMessage = ex.Message, Success = false };
            return BadRequest(errorResponse);
        }

    }
}