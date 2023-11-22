using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.Core.UseCases
{
    public class ChallengeService : CrudService<ChallengeDto, Challenge>, IChallengeService
    {
        public ChallengeService(ICrudRepository<Challenge> crudRepository, IMapper mapper) : base(crudRepository, mapper)
        {
        }
    }
}
