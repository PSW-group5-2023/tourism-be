using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases
{
    public class RecommenderService 
    {
        private readonly ITourRepository _tourRepository;
        private readonly IPreferencesRepository _preferencesRepository;
        public RecommenderService(ITourRepository tourRepository, IPreferencesRepository preferencesRepository)
        {
            _tourRepository = tourRepository;
            _preferencesRepository = preferencesRepository;
        }

   

    }
}
