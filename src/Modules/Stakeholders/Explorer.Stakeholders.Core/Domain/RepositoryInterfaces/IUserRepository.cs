namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;

public interface IUserRepository
{
    bool Exists(string username);
    User? Get(long userId);
    User? GetActiveByName(string username);
    User? GetByUsername(string username);
    User Create(User user);
    string GetUsername(long userId);
    List<User> GetAll();

    User Update(User user);
}