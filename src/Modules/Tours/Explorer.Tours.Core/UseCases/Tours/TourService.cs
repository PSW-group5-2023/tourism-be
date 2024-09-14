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
using Explorer.Encounters.API.Internal;
using Explorer.Tours.Core.Domain.Sessions;

namespace Explorer.Tours.Core.UseCases.Tours
{
    public class TourService : CrudService<TourDto, Tour>, ITourService, IInternalTourService
    {
        private readonly ITourRepository _tourRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly ICheckpointRepository _checkpointRepository;
        private readonly ICheckpointService _checkpointService;
        private readonly ITourRatingService _tourRatingService;
        private readonly IInternalBoughtItemService _internalBoughtItemService;
        private readonly IInternalPersonService _internalPersonService;
        private readonly IQuizAchievementMobileInternalService _quizMobileInternalService;
        protected readonly IMapper _mapper;

        public TourService(ITourRepository repository, ICheckpointRepository checkpointRepository, ISessionRepository sessionRepository, IMapper mapper, ICheckpointService checkpointService, ITourRatingService tourRatingService,
            IInternalBoughtItemService internalBoughtItemService, IInternalPersonService internalPersonService, IQuizAchievementMobileInternalService quizMobileInternalService) : base(repository, mapper)
        {
            _tourRepository = repository;
            _sessionRepository = sessionRepository;
            _checkpointRepository = checkpointRepository;
            _checkpointService = checkpointService;
            _tourRatingService = tourRatingService;
            _internalBoughtItemService = internalBoughtItemService;
            _internalPersonService = internalPersonService;
            _quizMobileInternalService = quizMobileInternalService; 
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

        public Result<PagedResult<TourMobileDto>> GetPagedMobileByLocation(int page, int pageSize, LocationMobileDto location)
        {

            var tours = GetPagedMobile(0, 0,"").Value.Results;
            var resultTours = new PagedResult<TourMobileDto>(new List<TourMobileDto>(), 0);

            if (location.Latitude == null && location.Longitude == null)
            {
                foreach (TourMobileDto tour in tours)
                {
                    resultTours.Results.Add(tour);
                }

                return resultTours;
            }

            List<TourMobileDto> filteredTours = new List<TourMobileDto>();
            foreach (var tour in tours)
            {
                LocationMobileDto locaion = new LocationMobileDto( location.Latitude, location.Longitude, location.Radius);
                if (CheckIfAnyKeyPointInRange(tour.Checkpoints,location))
                {
                    filteredTours.Add(tour);
                    
                }
            }

            return new PagedResult<TourMobileDto>(filteredTours,filteredTours.Count);
        }

        public bool CheckIfAnyKeyPointInRange(List<CheckpointMobileDto> checkpoints, LocationMobileDto location)
        {
            return checkpoints.Any(checkpoint => IsInRange(checkpoint, location));
        }

        public bool IsInRange(CheckpointMobileDto checkpoint, LocationMobileDto location)
        {
            double distance;
            int earthRadius = 6371000;
            double radiusInDegrees = location.Radius*1000 * 360 / (2 * Math.PI * earthRadius);
            distance = Math.Sqrt(Math.Pow((double)(checkpoint.Latitude - location.Latitude), 2) +
                                 Math.Pow((double)(checkpoint.Longitude - location.Longitude), 2));
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

        public Result<PagedResult<TourMobileDto>> GetPagedMobile(int page, int pageSize, string order)
        {
            var result = CrudRepository.GetPaged(page, pageSize).Results.Where(x=>x.Status== TourStatus.Published).ToList();
            var tours = result;
            if (order.Equals("latest"))
            {
                tours=tours.OrderByDescending(t => t.PublishedDate).ToList();
            }
            if (order.Equals("popular"))
            {
                tours = tours.OrderByDescending(t => GetCompletedSessionCount((int)t.Id)).ToList();
            }
            var tourDtos = new List<TourMobileDto>();

            foreach (var tour in tours)
            {
                var tourDto = _mapper.Map<TourMobileDto>(tour);

                var ratingResult = _tourRatingService.GetAverageTourRating((int)tour.Id);
                if (ratingResult.IsSuccess)
                {
                    tourDto.Rating = ratingResult.Value;
                }
                else
                {
                    tourDto.Rating = 0;
                }

                var checkpoints = _checkpointRepository.GetByTourId(tour.Id);
                var checkpointDtos = new List<CheckpointMobileDto>();

                foreach (var checkpoint in checkpoints)
                {
                    var checkpointDto = new CheckpointMobileDto
                    {
                        Id = checkpoint.Id,
                        Name = checkpoint.Name,
                        Description = checkpoint.Description,
                        Image = checkpoint.Image.ToString(),
                        Latitude = checkpoint.Latitude,
                        Longitude = checkpoint.Longitude,
                        Questions = new List<TourModuleQuizMobileDto>(),
                        AchievementMobileDto = null
                    };

                    var quizResult = _quizMobileInternalService.GetQuestionsByCheckpointId((int)checkpoint.Id);

                    if (quizResult.IsSuccess)
                    {
                        var quizAchievementMobileDto = quizResult.Value;
                   
                        checkpointDto.AchievementMobileDto = quizAchievementMobileDto.Achievement != null 
                            ? new TourModuleAchievementMobileDto
                            {
                                Id = quizAchievementMobileDto.Achievement.Id,
                                Name = quizAchievementMobileDto.Achievement.Name,
                                Description = quizAchievementMobileDto.Achievement.Description,
                                Icon = quizAchievementMobileDto.Achievement.Icon,
                                Rarity = quizAchievementMobileDto.Achievement.Rarity,
                                CraftingRecipe = quizAchievementMobileDto.Achievement.CraftingRecipe
                            }
                            : null;

                        checkpointDto.Questions = quizAchievementMobileDto.Questions?.Select(q => new TourModuleQuizMobileDto
                        {
                            QuestionId = q.QuestionId,
                            Question = q.Question,
                            Answers = q.Answers?.Select(a => new TourModuleAnswerMobileDto
                            {
                                QuestionId = a.QuestionId,
                                Answer = a.Answer,
                                IsTrue = a.IsTrue
                            }).ToList() ?? new List<TourModuleAnswerMobileDto>()
                        }).ToList() ?? new List<TourModuleQuizMobileDto>();
                    }

                    checkpointDtos.Add(checkpointDto);
                }

                tourDto.Checkpoints = checkpointDtos;
                tourDtos.Add(tourDto);
            }
            
            var pagedResult = new PagedResult<TourMobileDto>(tourDtos, tourDtos.Count);
            return Result.Ok(pagedResult);
        }

        public Result<PagedResult<TourMobileDto>> GetPagedSortedByLatestMobile(int page, int pageSize)
        {
            var result = GetPagedMobile(page, pageSize,"latest").Value.Results.ToList(); 
            var pagedResult = new PagedResult<TourMobileDto>(result, result.Count);
            return Result.Ok(pagedResult);
          
        }

        public Result<PagedResult<TourMobileDto>> GetPagedSortedByPopularMobile(int page, int pageSize)
        {
            var result = GetPagedMobile(page,pageSize,"popular").Value.Results;
           
        
            var pagedResult = new PagedResult<TourMobileDto>(result, result.Count);
            return Result.Ok(pagedResult);
        }

        public Result<PagedResult<TourMobileDto>> GetPagedMobileByRating(int page, int pageSize, int rating)
        {
            var list = GetPagedMobile(page, pageSize,"");

            var newList = list.Value.Results.Where(x => x.Rating>=rating);
            var pagedResult = new PagedResult<TourMobileDto>(newList.ToList(), newList.Count());

            return Result.Ok(pagedResult);
        }

        public Result<PagedResult<TourMobileDto>> GetPagedMobileByLocationAndRating(int page, int pageSize, LocationMobileDto location, int rating)
        {         
            var locationResult = GetPagedMobileByLocation(page, pageSize, location);

            if (!locationResult.IsSuccess)
                return Result.Fail<PagedResult<TourMobileDto>>(locationResult.Errors);
       
            var filteredByRating = locationResult.Value.Results.Where(x => x.Rating >= rating).ToList();

            var pagedResult = new PagedResult<TourMobileDto>(filteredByRating, filteredByRating.Count);

            return Result.Ok(pagedResult);
        }

        private int GetCompletedSessionCount(int tourId)
        {
            return _sessionRepository.GetCountByTourIdAndStatus(tourId, SessionStatus.COMPLETED);
        }


        public Result<TourMobileDto> GetMobile(int id)
        {
            try
            {
                var tour = CrudRepository.Get(id);
                if (tour == null)
                {
                    return Result.Fail(FailureCode.NotFound).WithError("Tour not found.");
                }

                var tourMobileDto = _mapper.Map<TourMobileDto>(tour);

                var ratingResult = _tourRatingService.GetAverageTourRating(id);
                if (ratingResult.IsSuccess)
                {
                    tourMobileDto.Rating = ratingResult.Value;
                }
                else
                {
                    tourMobileDto.Rating = 0;
                }

                var checkpoints = _checkpointRepository.GetByTourId(id);
                var checkpointDtos = new List<CheckpointMobileDto>();

                foreach (var checkpoint in checkpoints)
                {
                    var checkpointDto = new CheckpointMobileDto
                    {
                        Id = checkpoint.Id,
                        Name = checkpoint.Name,
                        Description = checkpoint.Description,
                        Image = checkpoint.Image.ToString(),
                        Latitude = checkpoint.Latitude,
                        Longitude = checkpoint.Longitude,
                        Questions = new List<TourModuleQuizMobileDto>(),
                        AchievementMobileDto = null
                    };

                    var quizResult = _quizMobileInternalService.GetQuestionsByCheckpointId((int)checkpoint.Id);

                    if (quizResult.IsSuccess)
                    {
                        var quizAchievementMobileDto = quizResult.Value;

                        checkpointDto.AchievementMobileDto = quizAchievementMobileDto.Achievement != null
                            ? new TourModuleAchievementMobileDto
                            {
                                Id = quizAchievementMobileDto.Achievement.Id,
                                Name = quizAchievementMobileDto.Achievement.Name,
                                Description = quizAchievementMobileDto.Achievement.Description,
                                Icon = quizAchievementMobileDto.Achievement.Icon,
                                Rarity = quizAchievementMobileDto.Achievement.Rarity,
                                CraftingRecipe = quizAchievementMobileDto.Achievement.CraftingRecipe
                            }
                            : null;

                        checkpointDto.Questions = quizAchievementMobileDto.Questions?.Select(q => new TourModuleQuizMobileDto
                        {
                            QuestionId = q.QuestionId,
                            Question = q.Question,
                            Answers = q.Answers?.Select(a => new TourModuleAnswerMobileDto
                            {
                                QuestionId = a.QuestionId,
                                Answer = a.Answer,
                                IsTrue = a.IsTrue
                            }).ToList() ?? new List<TourModuleAnswerMobileDto>()
                        }).ToList() ?? new List<TourModuleQuizMobileDto>();
                    }

                    checkpointDtos.Add(checkpointDto);
                }

                tourMobileDto.Checkpoints = checkpointDtos;

                return Result.Ok(tourMobileDto);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
           
        }

        
    }
}
