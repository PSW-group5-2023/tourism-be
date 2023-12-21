using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.API.Dtos;

namespace Explorer.Stakeholders.Core.Domain;

public class User : Entity
{
    public string Username { get; private set; }
    public string Password { get; private set; }
    public UserRole Role { get; private set; }
    public bool IsActive { get; set; }
    public double? Latitude { get; init; }
    public double? Longitude { get; init; }

    public User(string username, string password, UserRole role, bool isActive, double? latitude, double? longitude)
    {
        Username = username;
        Password = password;
        Role = role;
        IsActive = isActive;
        Latitude = latitude;
        Longitude = longitude;
        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Username)) throw new ArgumentException("Invalid Name");
        if (string.IsNullOrWhiteSpace(Password)) throw new ArgumentException("Invalid Surname");
        if (Latitude is > 90 or < -90) throw new ArgumentException("Invalid latitude");
        if (Longitude is > 180 or < -180) throw new ArgumentException("Invalid longitude");
    }

    public string GetPrimaryRoleName()
    {
        return Role.ToString().ToLower();
    }
}

public enum UserRole
{
    Administrator,
    Author,
    Tourist
}