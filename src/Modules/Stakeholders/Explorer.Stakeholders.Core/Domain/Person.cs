using Explorer.BuildingBlocks.Core.Domain;
using System.Net.Mail;

namespace Explorer.Stakeholders.Core.Domain;

public class Person : Entity
{
    public long UserId { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public string Email { get; init; }
    public Uri ProfilePic { get; init; }
    public string Biography { get; init; }
    public string Motto { get; init; }

    public Person(long userId, string name, string surname, string email, Uri profilePic, string biography, string motto) : this(userId, name, surname, email)
    {
        ProfilePic = profilePic;
        Biography = biography;
        Motto = motto;

        ValidateProfile();
    }

    public Person(long userId, string name, string surname, string email)
    {
        UserId = userId;
        Name = name;
        Surname = surname;
        Email = email;
        Validate();
    }

    private void Validate()
    {
        if (UserId == 0) throw new ArgumentException("Invalid UserId");
        if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
        if (string.IsNullOrWhiteSpace(Surname)) throw new ArgumentException("Invalid Surname");
        if (!MailAddress.TryCreate(Email, out _)) throw new ArgumentException("Invalid Email");
    }

    private void ValidateProfile()
    {
        if (!Uri.TryCreate(ProfilePic.AbsoluteUri, UriKind.Absolute, out Uri result)) throw new ArgumentNullException("Invalid uri");
        if (string.IsNullOrEmpty(Biography)) throw new ArgumentNullException("Invalid biography");
        if (string.IsNullOrEmpty(Motto)) throw new ArgumentNullException("Invalid motto");
    }
}