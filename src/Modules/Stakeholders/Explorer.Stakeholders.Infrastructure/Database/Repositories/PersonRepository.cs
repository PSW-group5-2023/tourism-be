using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly StakeholdersContext _dbContext;

        public PersonRepository(StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Person? Get(int id)
        {
            var query = from person in _dbContext.People
                        join user in _dbContext.Users on person.UserId equals user.Id
                        where user.Role != UserRole.Administrator
                        select person;

            return query.FirstOrDefault(p => p.Id == id);
        }

        public List<Person> GetAuthorsAndTourists()
        {
            var query = from person in _dbContext.People
                        join user in _dbContext.Users on person.UserId equals user.Id
                        where user.Role == UserRole.Author || user.Role == UserRole.Tourist
                        select person;

            return query.ToList();
        }

        public Person Update(Person person)
        {
            try
            {
                var result = _dbContext.People.Update(person).Entity;
                _dbContext.SaveChanges();
                return result;
            }
            catch (DbUpdateException e)
            {
                throw new KeyNotFoundException(e.Message);
            }

            return person;
        }
    }
}
