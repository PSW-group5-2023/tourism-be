using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public
{
    public interface ITourPreferencesService
    {
        Result<TourPreferencesDto> Create(TourPreferencesDto preferences);
        Result<TourPreferencesDto> GetByUserId(long userId);
        Result Delete(int id);
    }
}
