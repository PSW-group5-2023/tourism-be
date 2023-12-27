using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Execution;
using Explorer.Tours.Core.Domain.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Explorer.Tours.API.Internal;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Core.UseCases.Execution
{
    public class InternalPositionSimulatorService : BaseService<PositionSimulatorDto, PositionSimulator>, IInternalPositionSimulatorService
    {
        public IPositionSimulatorRepository _positionSimulatorRepository;

        public InternalPositionSimulatorService(IPositionSimulatorRepository positionSimulatorRepository, IMapper mapper) : base(mapper) 
        {
            _positionSimulatorRepository = positionSimulatorRepository;
        }

        public Result<PositionSimulatorDto> GetByTouristId(long touristId)
        {
            try
            {
                return MapToDto(_positionSimulatorRepository.GetByTouristId(touristId));
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }
    }
}
