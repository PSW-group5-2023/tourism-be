using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Infrastructure.Database.Repositories
{
    public class InternalBoughtItemDatabaseRepository : IInternalBoughtItemDatabaseRepository
    {
        private readonly PaymentsContext _dbContext;

        public InternalBoughtItemDatabaseRepository(PaymentsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BoughtItem CreateBoughtItem(BoughtItem item)
        {
            _dbContext.BoughtItems.Add(item);
            _dbContext.SaveChanges();

            return item;
        }
    }
}
