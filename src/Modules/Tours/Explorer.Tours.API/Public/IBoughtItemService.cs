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
        Result<List<TourDto>> GetUnusedTours(long userId);
        Result<List<TourDto>> GetUsedTours(long userId);
        Result Create(List<BoughtItemDto> items);
        Result DeleteItem(long tourId, long userId);
        public Result UpdateItem(long userId, long tourId);
    }
}