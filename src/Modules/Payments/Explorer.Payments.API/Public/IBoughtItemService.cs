using Explorer.Payments.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.API.Public
{
    public interface IBoughtItemService
    {
        Result Create(List<BoughtItemDto> items);
        Result DeleteItem(long tourId, long userId);
        Result UpdateItem(long userId, long tourId);
        Result<List<ListedTourDto>> GetUnusedTours(int userId);
        Result<List<ListedTourDto>> GetUsedTours(int userId);
    }
}
