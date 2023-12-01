﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Public
{
    public interface ILocationChallengeService
    {      
        Result<LocationChallengeDto> Create(LocationChallengeDto challengeDto);
        Result<PagedResult<LocationChallengeDto>> GetPaged(int page, int pageSize);
    }
}
