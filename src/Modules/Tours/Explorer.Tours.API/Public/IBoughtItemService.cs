﻿using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public
{
    public interface IBoughtItemService
    {
        Result<List<TourDto>> GetItemsByUserId(long userId);
        Result Create(List<BoughtItemDto> items);

        Result DeleteItem(long tourId, long userId);
    }
}