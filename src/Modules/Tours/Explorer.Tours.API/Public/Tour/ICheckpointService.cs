﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using FluentResults;

namespace Explorer.Tours.API.Public.Tour
{
    public interface ICheckpointService
    {
        Result<PagedResult<CheckpointDto>> GetPaged(int page, int pageSize);
        Result<List<CheckpointDto>> GetByTourId(long tourId);
        Result<CheckpointDto> Get(int id);
        Result<CheckpointDto> Create(CheckpointDto tourKeyPoint);
        Result<CheckpointDto> Update(CheckpointDto tourKeyPoint);
        Result Delete(int id);
    }
}
