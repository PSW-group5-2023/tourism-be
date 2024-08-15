﻿namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;

public interface IUserRepository
{
    bool Exists(string username);
    User? Get(long userId);
    User? GetActiveByName(string username);
    User? GetByUsername(string username);
    User? GetByEmail(string email);
    User? GetByEmailToken(string token);
    User? GetByResetPasswordToken(string token);
    User Create(User user);
    long GetPersonId(long userId);

    string GetUsername(long userId);
    List<User> GetAll();

    User Update(User user);
}