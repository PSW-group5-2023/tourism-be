﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Payments.Core.Domain;

namespace Explorer.Payments.Core.Domain.RepositoryInterfaces
{
    public interface IBoughtItemRepository
    {
        BoughtItem AddToCart(BoughtItem item);
        void DeleteItem(long tourId, long userId);
        void GetItemToUpdate(long userId, long tourId);
        List<BoughtItem> GetAll();
        List<BoughtItem> GetAllByUserId(int userId);
    }
}