using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class TourPreferencesService : CrudService<TourPreferencesDto, TourPreferences>, ITourPreferencesService
    {
        public TourPreferencesService(ICrudRepository<TourPreferences> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
