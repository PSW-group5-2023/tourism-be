﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using FluentResults;

namespace Explorer.Encounters.API.Public
{
    public interface IUserExperienceService
    {
        Result<PagedResult<UserExperienceDto>> GetPaged(int page, int pageSize);
        Result<UserExperienceDto> Create(long userId);
        Result<UserExperienceDto> Update(UserExperienceDto userExperienceDto);
        Result Delete(int id);
        Result<UserExperienceDto> Get(int id);
        Result<UserExperienceDto> GetByUserId(long userId);
        Result<UserExperienceDto> AddXP(long id,int xp);
    }
}
