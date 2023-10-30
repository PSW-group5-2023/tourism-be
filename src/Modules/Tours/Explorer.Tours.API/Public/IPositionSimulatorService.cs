using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public
{
    public interface IPositionSimulatorService
    {
        Result<PositionSimulatorDto> Create(PositionSimulatorDto positionSimulatorDto);
        Result<PositionSimulatorDto> Update(PositionSimulatorDto positionSimulatorDto);
        Result<PagedResult<PositionSimulatorDto>> GetPaged(int page, int pagedSize);
        Result<PositionSimulatorDto> Get(int id);

    }
}
