using Explorer.Stakeholders.API.Dtos;
using FluentResults;

namespace Explorer.Stakeholders.API.Public;

public interface IAuthenticationService
{
    Result<AuthenticationTokensDto> Login(CredentialsDto credentials);
    Result<AuthenticationTokensDto> RegisterTourist(AccountRegistrationDto account);
    Result<string> ChangePasswordRequest(string email);

    Result<string> ChangePassword(ChangePasswordDto changePassword);

    Result<string> GetUsername(long id);
    Result<AuthenticationTokensDto> ActivateUser(string token);
    public Result<AuthenticationTokensDto> RegisterGuest(AccountMobileDto account);
}