using Explorer.Stakeholders.API.Internal;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories;

public class UserDatabaseRepository : IUserRepository
{
    private readonly StakeholdersContext _dbContext;

    public UserDatabaseRepository(StakeholdersContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Exists(string username)
    {
        return _dbContext.Users.Any(user => user.Username == username);
    }
    public User? Get(long userId)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null) throw new KeyNotFoundException("Not found");
        return user;
    }


    public User? GetActiveByName(string username)
    {
        return _dbContext.Users.FirstOrDefault(user => user.Username == username && user.IsActive);
    }

    public User? GetByUsername(string username)
    {
        return _dbContext.Users.FirstOrDefault(user => user.Username == username);
    }

    public User? GetByEmail(string email)
    {
        return _dbContext.Users.FirstOrDefault(user => user.Email == email);
    }

    public User? GetByEmailToken(string token)
    {
        return _dbContext.Users.FirstOrDefault(user => user.EmailVerificationToken == token);
    }

    public User? GetByResetPasswordToken(string token)
    {
        return _dbContext.Users.FirstOrDefault(user => user.ResetPasswordToken == token);
    }

    public User Create(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
        return user;
    }

    public long GetPersonId(long userId)
    {
        var person = _dbContext.People.FirstOrDefault(i => i.UserId == userId);
        if (person == null) throw new KeyNotFoundException("Not found.");
        return person.Id;
    }

    public string GetUsername(long userId)
    {
        var user = _dbContext.Users.FirstOrDefault(i => i.Id == userId);
        if (user == null) throw new KeyNotFoundException("Not found.");
        return user.Username;
    }

    public List<User> GetAll()
    {
        return _dbContext.Users.ToList();
    }

    public Task<IQueryable<User>> GetAllGuestAsync()
    {
        IQueryable<User> query = _dbContext.Users.Where(u => u.Role == UserRole.Guest).AsQueryable();
        return Task.FromResult(query);
    }

    public User Update(User newUser)
    {
        var user = _dbContext.Users.FirstOrDefault(x => x.Id == newUser.Id);
        user = newUser;
        _dbContext.SaveChanges();
        return user;
    }

    public async Task DeleteGuestsAsync(List<User> users, CancellationToken cancellationToken)
    {
        _dbContext.Users.RemoveRange(users);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    public void SetRefreshToken(string username,string refreshToken)
    {
        var user= GetByUsername(username);
        user.RefreshToken = refreshToken;
        _dbContext.SaveChanges();
    }
}