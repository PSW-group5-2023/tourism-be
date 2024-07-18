using Explorer.Tours.Core.Domain.Equipment;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class EquipmentTrackingRepository :  IEquipmentTrackingRepository
    {
        private readonly ToursContext _dbContext;
        private readonly DbSet<EquipmentTracking> _dbSet;
        public EquipmentTrackingRepository(ToursContext dbContext) {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<EquipmentTracking>();
        }
        public EquipmentTracking GetByTouristId(long id)
        {
            return _dbContext.EquipmentTrackings.FirstOrDefault(et => et.TouristId == id);
        }

        public EquipmentTracking Update(EquipmentTracking entity)
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
        public EquipmentTracking Create(EquipmentTracking entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
