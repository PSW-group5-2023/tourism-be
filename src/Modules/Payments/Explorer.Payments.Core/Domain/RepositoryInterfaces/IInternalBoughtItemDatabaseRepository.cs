﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Domain.RepositoryInterfaces
{
    public interface IInternalBoughtItemDatabaseRepository
    {
        BoughtItem CreateBoughtItem(BoughtItem item);

        List<BoughtItem> GetByUserId(int userId);

        List<BoughtItem> GetByTourId(long tourId);
    }
}
