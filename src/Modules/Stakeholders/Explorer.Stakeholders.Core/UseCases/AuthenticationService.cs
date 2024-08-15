﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Explorer.BuildingBlocks.Core.Security;
using Explorer.BuildingBlocks.Infrastructure.Email;
using Explorer.Stakeholders.API.Internal;
using System;
using System.Data.SqlTypes;
using AutoMapper;
using System.Linq.Expressions;

namespace Explorer.Stakeholders.Core.UseCases;

public class AuthenticationService : BaseService<UserDto, User>, IAuthenticationService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly ICrudRepository<Person> _personRepository;
    private readonly IEmailSendingService _emailSendingService;
    private readonly IPersonRepository _personeRep;

    public AuthenticationService(IUserRepository userRepository, ICrudRepository<Person> personRepository, ITokenGenerator tokenGenerator,
        IEmailSendingService emailSendingService, IPersonRepository personeRep, IMapper mapper) : base(mapper)
    {
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
        _personRepository = personRepository;
        _emailSendingService = emailSendingService;
        _personeRep = personeRep;
    }

    public Result<AuthenticationTokensDto> Login(CredentialsDto credentials)
    {
        var user = _userRepository.GetActiveByName(credentials.Username);
        if (user == null || !PasswordEncoder.Matches(credentials.Password,user.Password) ) return Result.Fail(FailureCode.NotFound);
        if (user.Role == UserRole.Guest) return Result.Fail(FailureCode.InvalidArgument);

        return _tokenGenerator.GenerateAccessToken(user);
    }

    public Result<RegisteredUserDto> RegisterTourist(AccountRegistrationDto account)
    {
        if (_userRepository.Exists(account.Username))
        {
            var user = _userRepository.GetByUsername(account.Username);
            if (user.Role != UserRole.Guest)
                return Result.Fail(FailureCode.NonUniqueUsername);
            else
            {
                try
                {
                    user.Password = PasswordEncoder.Encode(account.Password);
                    user.Role = UserRole.Tourist;
                    user.IsActive = false;
                    user.Email = account.Email;
                    var emailVerificationToken = Guid.NewGuid().ToString();
                    user.EmailVerificationToken = emailVerificationToken;
                    sendVerificationEmail(user, emailVerificationToken);

                    var updatedUser = _userRepository.Update(user);
                    sendVerificationEmail(user, Guid.NewGuid().ToString());
                    return new RegisteredUserDto(updatedUser.Id, updatedUser.Username, updatedUser.Role.ToString());
                }
                catch(ArgumentException e)
                {
                    return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
                }
            }
        }

        try
        {
            var user = _userRepository.Create(new User(account.Username, PasswordEncoder.Encode(account.Password), UserRole.Tourist, false, null, null, account.Email));
            var emailVerificationToken = Guid.NewGuid().ToString();
            sendVerificationEmail(user, emailVerificationToken);
            user.EmailVerificationToken = emailVerificationToken;
            user = _userRepository.Update(user);

            return new RegisteredUserDto(user.Id, user.Username, user.Role.ToString()) ;
        }
        catch (ArgumentException e)
        {
            return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
        }
    }
    public Result<AuthenticationTokensDto> RegisterGuest(AccountMobileDto account)
    {
        if (_userRepository.Exists(account.Username)) return Result.Fail(FailureCode.NonUniqueUsername);

        try
        {
            var user = _userRepository.Create(new User(account.Username, null, UserRole.Guest, true));

            return _tokenGenerator.GenerateAccessToken(user);
        }
        catch (ArgumentException e)
        {
            return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
        }
    }

    private Result<string> sendVerificationEmail(User user, string token)
    {
        try
        {
            string to = user.Email;
            string subject = "Email Verification";
            string body = $@"
            <html>
            <body>
                <p>Hello {to},</p><br>
                <p>Thank you for registering with our service. To verify your email address, please click on the link below:</p><br>
                <p><a href='https://via-ventura.com/verify-email?token={token}'>Verify Your Email Address</a></p><br>
                <p>For security reasons, this link will expire in 24 hours. If you're unable to use the link, copy and paste it into your browser's address bar.</p><br>
                <p>Thank you for choosing our service.</p>
                <p>Best regards,<br>ViaVentura team</p>
            </body>
            </html>";

            _emailSendingService.SendEmailAsync(to, subject, body, true);
            return "Email successfully sent for verification.";
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }

    public Result<string> ActivateUser(string token)
    {
        try
        {
            var user = _userRepository.GetByEmailToke(token);
            if (user == null) throw new ArgumentException("User with given email token doesn't exist");
            user.IsActive = true;
            _userRepository.Update(user);

            return Result.Ok("User activated successfully");
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }


    public Result<string> GetUsername(long id)
    {
        return _userRepository.GetUsername(id);
    }

    public Result<string> ChangePasswordRequest(string email)
    {
        try
        {
            Person person = _personeRep.GetByEmail(email);
            if (person == null) return Result.Fail(FailureCode.InvalidArgument).WithError("Invalid mail");
            User user = _userRepository.Get(person.UserId);
            string token = _tokenGenerator.GenerateResetPasswordToken(user, person.Id);
            user.ResetPasswordToken = token;
            user = _userRepository.Update(user);
            return sendChangePasswordEmail(person, user.ResetPasswordToken);
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }

    }

    private Result<string> sendChangePasswordEmail(Person person, string token)
    {
        try
        {
            string to = person.Email;
            string personName = person.Name;
            string subject = "Change password request";
            string body = $@"
                Hello {personName},

                We recently received a request to change the password associated with your account. If you initiated this request, please follow the link below to reset your password. If you did not make this request, please disregard this email.

                http://localhost:4200/reset-password?token={token}

                For security reasons, this link will expire in 24h. If you're unable to use the link, copy and paste it into your browser's address bar.

                Thank you for using our service.

                 Best regards,
                Travelo";
            _emailSendingService.SendEmailAsync(to, subject, body);
            return "Mail successfuly sent";
        }
        catch(Exception ex)
        {
            return Result.Fail(ex.Message);
        }

    }

    public Result<string> ChangePassword(ChangePasswordDto changePassword)
    {
        try
        {
            if (!doPasswordsMatch(changePassword.newPassword, changePassword.newPasswordConfirm))
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError("Passwords don't match");
            }
            long userId = getUserIdFromToken(changePassword.token);
            if (userId == 0)
            {
                return Result.Fail(FailureCode.NotFound).WithError("Invalid token"); 
            }
            User user = _userRepository.Get(userId);
            if (user == null)
            {
                return Result.Fail(FailureCode.NotFound).WithError("User not found");
            }
            if(user.ResetPasswordToken == null || user.ResetPasswordToken != changePassword.token)
            {
                return Result.Fail(FailureCode.NotFound).WithError("Invalid token");
            }
            if(isTokenExpired(changePassword.token))
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError("Expired token");
            }

            updatePassword(user, changePassword.newPassword);



            return "Password successfuly changed";



        }
        catch(Exception ex)
        {
            return Result.Fail(ex.Message);
        }

        
    }
    private bool doPasswordsMatch(string password, string passwordConfirm)
    {
        return password == passwordConfirm;
    }
    private long getUserIdFromToken(string token)
    {
        return _tokenGenerator.GetUserIdFromToken(token);
    }
    private bool isTokenExpired(string token)
    {
        DateTime tokenExpirationDate = _tokenGenerator.GetTokenExpirationTime(token);
        return tokenExpirationDate <= DateTime.UtcNow;
    }
    private void updatePassword(User user, string password)
    {
        user.UpdatePassword(PasswordEncoder.Encode(password));
        user.RemoveChangePasswordToken();
        user = _userRepository.Update(user);
    }
    private void activateUser(User user)
    {
        user.ActivateUser();
        user.RemoveEmailVerificationToken();
        user = _userRepository.Update(user);
    }
}