﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Dtos.Tourist;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public
{
    public interface IUserInformationService
    {
        Result<PagedResult<UserInformationDto>> GetPaged(int page, int pageSize);
        Result<PagedResult<UserInformationDto>> Join(Result<PagedResult<UserInformationDto>> users, Result<PagedResult<UserInformationDto>> persons);
        Result<UserInformationMobileDto> GetMobile(int userId);
        Result Delete(int userId);
        Result<UserInformationMobileDto> ChangeAvatarImage(string image, int userId);
    }
}
