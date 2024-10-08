﻿using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.API.Dtos;
using System.Text.RegularExpressions;

namespace Explorer.Stakeholders.Core.Domain;

public class User : Entity
{
    private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled, TimeSpan.FromMilliseconds(2000));

    public string Username { get; private set; }
    public string? Password { get; set; }
    public UserRole Role { get; set; }
    public bool IsActive { get; set; }
    public string? ResetPasswordToken {  get; set; }
    public string? EmailVerificationToken { get; set; }
    public string? RefreshToken { get; set; }
    public string? Email {  get; set; }
    public DateTime? GuestDateTimeCreated { get; set; }
    public Uri? AvatarImage { get; set; }


    public User(string username, string password, UserRole role, bool isActive, string? resetPasswordToken = "", string? emailVerificationToken = null, string? refershToken = "", string? email = null, DateTime? guestDateTimeCreated = null, Uri? avatarImage=null)
    {
        Username = username;
        Password = password ;
        Role = role;
        IsActive = isActive;    
        ResetPasswordToken = resetPasswordToken;
        EmailVerificationToken = emailVerificationToken;
        RefreshToken = refershToken;
        Email = email;
        GuestDateTimeCreated = guestDateTimeCreated;
        AvatarImage = avatarImage;
        Validate();
    }

    public User(long id, string username, string password, UserRole role, bool isActive, string? resetPasswordToken = "", string? emailVerificationToken = null, string? email = null, DateTime? guestDateTimeCreated = null, Uri? avatarImage = null)
    {
        Id = id;
        Username = username;
        Password = password;
        Role = role;
        IsActive = isActive;
        ResetPasswordToken = resetPasswordToken;
        EmailVerificationToken = emailVerificationToken;
        Email = email;
        GuestDateTimeCreated = guestDateTimeCreated;
        AvatarImage = avatarImage;
        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Username)) throw new ArgumentException("Invalid Name");
        //if (string.IsNullOrWhiteSpace(Password)) throw new ArgumentException("Invalid Surname");

        if (!string.IsNullOrWhiteSpace(Email) && !EmailRegex.IsMatch(Email))
            throw new ArgumentException("Invalid Email format.");    
    }

    public string GetPrimaryRoleName()
    {
        return Role.ToString().ToLower();
    }


    public void UpdatePassword(string password)
    {
        Password = password;
    }
    public void RemoveChangePasswordToken()
    {
        ResetPasswordToken = null;
    }
    public void RemoveEmailVerificationToken()
    {
        EmailVerificationToken = null;
    }
    public void ActivateUser()
    {
        IsActive = true;
    }
    public void ChangeAvatarImage(string image)
    {
        AvatarImage = new System.Uri(image);
    }
}

public enum UserRole
{
    Administrator,
    Author,
    Tourist,
    Guest
}