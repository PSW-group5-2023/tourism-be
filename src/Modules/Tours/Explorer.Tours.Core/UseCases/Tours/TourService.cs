using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Internal;
using Explorer.Tours.API.Internal;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.Core.Domain.Equipment;
using Explorer.Tours.API.Dtos.Equipment;
using Explorer.Tours.API.Dtos.Tour.Tourist;
using Explorer.Tours.API.Public.Rating;

namespace Explorer.Tours.Core.UseCases.Tours
{
    public class TourService : CrudService<TourDto, Tour>, ITourService, IInternalTourService
    {
        private readonly ITourRepository _tourRepository;
        private readonly ICheckpointService _checkpointService;
        private readonly ITourRatingService _tourRatingService;
        private readonly IInternalBoughtItemService _internalBoughtItemService;
        private readonly IInternalPersonService _internalPersonService;
        protected readonly IMapper _mapper;


        public TourService(ITourRepository repository, IMapper mapper, ICheckpointService checkpointService, ITourRatingService tourRatingService,
            IInternalBoughtItemService internalBoughtItemService,
            IInternalPersonService internalPersonService) : base(repository, mapper)
        {
            _tourRepository = repository;
            _checkpointService = checkpointService;
            _tourRatingService = tourRatingService;
            _internalBoughtItemService = internalBoughtItemService;
            _internalPersonService = internalPersonService;
            _mapper = mapper;
        }

        public Result<TourDto> Archive(int id, int userId)
        {
            try
            {
                var tour = _tourRepository.Get(id);
                tour.Archive(userId);
                _tourRepository.SaveChanges();
                return MapToDto(tour);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                return Result.Fail(FailureCode.Forbidden).WithError(e.Message);
            }
        }

        public Result<TourDto> Publish(int id, int userId)
        {
            try
            {
                var tour = _tourRepository.Get(id);
                tour.Publish(userId);
                _tourRepository.SaveChanges();
                return MapToDto(tour);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                return Result.Fail(FailureCode.Forbidden).WithError(e.Message);
            }
        }

        public Result<PagedResult<TourDto>> GetPagedByAuthorId(int authorId, int page, int pageSize)
        {
            try
            {
                var author = _internalPersonService.GetByUserId(authorId);
                if (author.Value
                    == null) return Result.Fail(FailureCode.InvalidArgument).WithError("Author with id " + authorId + " doesnt exist");
                var result = _tourRepository.GetPagedByAuthorId(authorId, page, pageSize);
                return MapToDto(result);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result<TourDto> CreateCampaign(List<TourDto> tours, string name, string description, int touristId)
        {
            if (tours.Count < 2)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError("In order to create campaign, atleast 2 Tours have to be picked.");
            }

            int difficulty = 0;
            List<string> tags = new List<string>();
            TourStatus status = TourStatus.Draft;
            double price = 0;
            List<EquipmentDto> equipment = new List<EquipmentDto>();
            double distanceInKm = 0;
            DateTime? archivedDate = null;
            DateTime? publishedDate = null;
            List<TourDuration> durations = new List<TourDuration>();

            int counter = 0;

            foreach (var tour in tours)
            {
                distanceInKm += tour.DistanceInKm;
                difficulty += tour.Difficulty;
                tags = CombineCampaignTags(tags, tour.Tags);
                if (tour.Equipment != null) equipment = CombineCampaignEquipment(equipment, tour.Equipment);
                counter++;
            }

            TourDifficulty difficultyTemp = GetCampaignDifficulty(difficulty, counter);

            Tour campaign = new Tour(name, description, difficultyTemp, tags, status, price, touristId,
                distanceInKm, archivedDate, publishedDate, durations);

            var createdCampaign = Create(MapToDto(campaign));

            CreateDuplicateKeypoints(tours, createdCampaign.Value.Id);
            CreateBoughtItemForCampaign(touristId, createdCampaign.Value.Id);

            return MapToDto(campaign);
        }

        public void CreateBoughtItemForCampaign(int touristId, int campaignId)
        {
            BoughtItemDto boughtItemDto = new BoughtItemDto();
            boughtItemDto.UserId = touristId;
            boughtItemDto.TourId = campaignId;
            boughtItemDto.IsUsed = false;

            _internalBoughtItemService.CreateBoughtItem(boughtItemDto);
        }

        public void CreateDuplicateKeypoints(List<TourDto> tours, int campaignId)
        {
            List<CheckpointDto> checkpoints = new List<CheckpointDto>();
            int positionInCampaign = 1;
            foreach (var tour in tours)
            {
                checkpoints = _checkpointService.GetByTourId(tour.Id).Value;
                checkpoints = checkpoints.OrderBy(kp => kp.PositionInTour).ToList();
                foreach (var checkpoint in checkpoints)
                {
                    checkpoint.PositionInTour = positionInCampaign;
                    checkpoint.TourId = campaignId;
                    checkpoint.Id = 0;
                    _checkpointService.Create(checkpoint);
                    positionInCampaign++;
                }
            }
        }

        public int CalculateCampaignDifficulty(int difficultySum, int counter)
        {
            return difficultySum / counter;
        }

        public List<string> CombineCampaignTags(List<string> campaignTags, List<string> tourTags)
        {
            foreach (var tag in tourTags)
            {
                campaignTags.Add(tag);
            }

            return campaignTags;
        }

        public TourDifficulty GetCampaignDifficulty(int difficulty, int counter)
        {
            difficulty = CalculateCampaignDifficulty(difficulty, counter);

            if (difficulty == 0)
            {
                return TourDifficulty.Beginner;
            }
            else if (difficulty == 1)
            {
                return TourDifficulty.Intermediate;
            }
            else if (difficulty == 2)
            {
                return TourDifficulty.Advanced;
            }
            else
            {
                return TourDifficulty.Pro;
            }
        }

        public List<EquipmentDto> CombineCampaignEquipment(List<EquipmentDto> campaignEquipment, List<EquipmentDto> tourEquipment)
        {
            List<EquipmentDto> campaignEquipmentList = new List<EquipmentDto>(campaignEquipment);

            foreach (var equipmentId in tourEquipment)
            {
                if (!campaignEquipmentList.Contains(equipmentId))
                {
                    campaignEquipmentList.Add(equipmentId);
                }
            }

            return campaignEquipmentList;
        }

        public Result<PagedResult<TourDto>> GetPagedForSearch(string name, string[] tags, int page, int pageSize)
        {
            var tours = _tourRepository.GetPaged(page, pageSize);

            if (tags[0].Contains(","))
            {
                tags = tags[0].Split(",");
            }

            var filteredResults = tours.Results
                    .Where(tour => (tour.Name.ToLower().Contains(name.ToLower()) || name.Equals("empty")) &&
                                   tags.All(tag => tour.Tags.Any(tourTag =>
                                       tourTag.ToLower() == tag.ToLower() || tag == "empty")))
                    .Select(MapToDto)
                    .ToList();

            return new PagedResult<TourDto>(new List<TourDto>(filteredResults), filteredResults.Count); ;
        }

        public Result<PagedResult<TourDto>> GetPagedForSearchByLocation(int page, int pageSize, int touristId)
        {
            double radius = 40000;
            var person = _internalPersonService.Get(touristId);
            var tours = _tourRepository.GetPaged(page, pageSize);
            var publishedTours = tours.Results.Where(tour => tour.Status == TourStatus.Published).ToList();
            var resultTours = new PagedResult<TourDto>(new List<TourDto>(), 0);

            if (person.Value.Latitude == null && person.Value.Longitude == null)
            {
                foreach (Tour tour in publishedTours)
                {
                    resultTours.Results.Add(MapToDto(tour));
                }

                return resultTours;
            }

            PagedResult<TourDto> filteredTours = new PagedResult<TourDto>(new List<TourDto>(), 0);
            foreach (var tour in tours.Results)
            {
                if (tour.Status == TourStatus.Published && CheckIfAnyKeyPointInRange(tour.Checkpoints,
                        person.Value.Latitude, person.Value.Longitude, radius))
                {
                    filteredTours.Results.Add(MapToDto(tour));
                }
            }

            return filteredTours;
        }

        public bool CheckIfAnyKeyPointInRange(List<Checkpoint> checkpoints, double? lat, double? lon, double radius)
        {
            return checkpoints.Any(checkpoint => IsInRange(checkpoint, lat, lon, radius));
        }

        public bool IsInRange(Checkpoint checkpoint, double? lat, double? lon, double radius)
        {
            double distance;
            int earthRadius = 6371000;
            double radiusInDegrees = radius * 360 / (2 * Math.PI * earthRadius);
            distance = Math.Sqrt(Math.Pow((double)(checkpoint.Latitude - lat), 2) +
                                 Math.Pow((double)(checkpoint.Longitude - lon), 2));
            return distance <= radiusInDegrees;
        }

        public Result<PagedResult<TourDto>> GetPagedByIds(List<int> ids, int page, int pageSize)
        {
            var result = _tourRepository.GetPagedByIds(ids, page, pageSize);
            return MapToDto(result);
        }
        public List<TourDto> GetAllByAuthorId(int authorId)
        {
            var result = _tourRepository.GetPagedByAuthorId(authorId, 0, 0);
            return MapToDto(result.Results).Value;
        }
        public Result<PagedResult<TourDto>> GetAllPagedByAuthorId(int authorId)
        {
            return GetPagedByAuthorId(authorId, 0, 0);
        }

        public Result<TourDto> GetById(long id)
        {
            return MapToDto(_tourRepository.Get(id));
        }

        public Result<PagedResult<TourMobileDto>> GetPagedMobile(int page, int pageSize)
        {
            var result = CrudRepository.GetPaged(page, pageSize);
            var mappedResult = result.Results.Select(tour => _mapper.Map<TourMobileDto>(tour)).ToList();

            foreach (var tour in mappedResult)
            {
                var ratingResult = _tourRatingService.GetAverageTourRating((int)tour.Id);
                if (ratingResult.IsSuccess)
                {
                    tour.Rating = ratingResult.Value;
                }
                else
                {
                    tour.Rating = 0;
                }
            }

            var pagedResult = new PagedResult<TourMobileDto>(mappedResult, result.TotalCount);
            return Result.Ok(pagedResult);
        }

        public Result<TourMobileDto> GetMobile(int id)
        {
            try
            {
                var result = CrudRepository.Get(id);
                if (result == null)
                {
                    return Result.Fail(FailureCode.NotFound).WithError("Tour not found.");
                }

                var tourMobileDto = _mapper.Map<TourMobileDto>(result);

                var ratingResult = _tourRatingService.GetAverageTourRating(id);
                if (ratingResult.IsSuccess)
                {
                    tourMobileDto.Rating = ratingResult.Value;
                }
                else
                {
                    tourMobileDto.Rating = 0;
                }

                return Result.Ok(tourMobileDto);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

    }
}
