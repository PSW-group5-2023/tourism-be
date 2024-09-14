using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Dtos.Tourist;
using FluentResults;

namespace Explorer.Stakeholders.API.Public;

public interface IAuthenticationService
{
    Result<AuthenticationTokensDto> Login(CredentialsDto credentials);
    Result<RegisteredUserDto> RegisterTourist(AccountRegistrationDto account);
    Result<string> ChangePasswordRequest(string password);
    Result<bool> IsTokenExpired(string token);
    Result<string> ChangePassword(ChangePasswordDto changePassword);
    Result<AuthenticationTokensDto> Refresh(AuthenticationTokensDto tokens);
    Result<string> GetUsername(long id);
    Result<string> ActivateUser(string token);
    Result<AuthenticationTokensDto> RegisterGuest(AccountMobileDto account);
    Result<string> ChangePasswordMobile(ChangePasswordMobileDto changePassword, int userId);
}