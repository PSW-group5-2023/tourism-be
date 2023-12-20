using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Internal;
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
        private readonly ITourRatingRepository _tourRatingRepository;

        private readonly IInternalBoughtItemService _internalBoughtItemService;

        public RecommenderService(ITourRepository tourRepository, IPreferencesRepository preferencesRepository, ITourRatingRepository tourRatingRepository, IInternalBoughtItemService internalBoughtItemService)
        {
            _tourRepository = tourRepository;
            _preferencesRepository = preferencesRepository;
            _tourRatingRepository = tourRatingRepository;
            _internalBoughtItemService = internalBoughtItemService;
        }

        

    }
}
