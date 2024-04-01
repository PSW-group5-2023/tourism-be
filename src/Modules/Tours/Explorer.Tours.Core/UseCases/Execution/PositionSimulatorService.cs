using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Execution;
using Explorer.Tours.API.Public.Execution;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Sessions;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Core.UseCases.Execution
{
    public class PositionSimulatorService : CrudService<PositionSimulatorDto, PositionSimulator>, IPositionSimulatorService
    {
        private readonly IPositionSimulatorRepository _positionSimulatorRepository;
        public PositionSimulatorService(IPositionSimulatorRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _positionSimulatorRepository = repository;        
        }

        public override Result<PositionSimulatorDto> Create(PositionSimulatorDto entity)
        {
            try
            {
                return base.Create(entity);

            }
            catch (DbUpdateException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
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

        public override Result<PositionSimulatorDto> Update(PositionSimulatorDto entity)
        {
            try
            {
                return base.Update(entity);
            }
            catch (DbUpdateException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }
    }

}