using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.Core.UseCases
{
    public class EncounterExecutionService : CrudService<EncounterExecutionDto, EncounterExecution>, IEncounterExecutionService
    {
        private readonly IEncounterExecutionRepository _encounterExecutionRepository;
        public EncounterExecutionService(IEncounterExecutionRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _encounterExecutionRepository = repository;
        }

        public Result<EncounterExecutionDto> Complete(long touristId, long challengeId)
        {
            throw new NotImplementedException();
        }

        public Result<EncounterExecutionDto> GetByTouristIdAndEnctounterId(long touristId, long encounterId)
        {
            try
            {
                var result = _encounterExecutionRepository.GetByTouristIdAndEncounterId(touristId, encounterId);
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }
    }
}
