using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.Core.Domain;
using Explorer.Achievements.Core.Domain.RepositoryInterfaces;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Infrastructure.Database.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        public readonly AchievementsContext _dbContext;
        private readonly DbSet<Inventory> _dbSet;
        public InventoryRepository(AchievementsContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Inventory>();
        }

        public Inventory Create(Inventory entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(long id)
        {
            var entity = Get(id);
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Inventory Get(long id)
        {
            var inventory= _dbSet.Where(x => x.Id == id).First();
            return inventory ?? throw new KeyNotFoundException("Not found: " + id);
        }

        public PagedResult<Inventory> GetPaged(int page, int pageSize)
        {
            var task = _dbSet.Include(x=>x.AchievementsId).GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public Inventory Update(Inventory entity)
        {
            try
            {
                _dbContext.Update(entity);
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new KeyNotFoundException(e.Message);
            }
            return entity;
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Result<Inventory> GetByUserId(int userId)
        {
            try
            {
                var inventory = _dbSet.Where(x => x.UserId == userId).FirstOrDefault();
                return inventory;
            }
            catch 
            {
                 throw new KeyNotFoundException("Not found by userId: " + userId);
            }
        }

    }
}
