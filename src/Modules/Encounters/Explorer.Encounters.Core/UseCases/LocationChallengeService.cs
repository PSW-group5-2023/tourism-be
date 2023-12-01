using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.Core.UseCases
{
    public class LocationChallengeService : CrudService<LocationChallengeDto, LocationChallenge>, ILocationChallengeService
    {
        public LocationChallengeService(ICrudRepository<LocationChallenge> crudRepository, IMapper mapper) : base(crudRepository,mapper) 
        { 
        }
    }
}
