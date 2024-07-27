using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos.Tourist;
using Explorer.Encounters.API.Internal;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Dtos.Tour.Tourist;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;

namespace Explorer.Tours.Core.UseCases.Tours
{
    public class CheckpointService : CrudService<CheckpointDto, Checkpoint>, ICheckpointService
    {
        private readonly ICheckpointRepository _checkpointRepository;
        private readonly IQuizAchievementMobileInternalService _quizMobileInternalService;
        private readonly IMapper _mapper;

        public CheckpointService(ICrudRepository<Checkpoint> repository, ICheckpointRepository checkpointRepository, IMapper mapper, IQuizAchievementMobileInternalService quizMobileInternalService) : base(repository, mapper)
        {
            _checkpointRepository = checkpointRepository;
            _quizMobileInternalService = quizMobileInternalService;
            _mapper = mapper;
        }

        public Result<List<CheckpointDto>> GetByTourId(long tourId)
        {
            List<CheckpointDto> tourKeyPointDtos = new List<CheckpointDto>();
            var tourKeyPoints = _checkpointRepository.GetByTourId(tourId);
            foreach (var tourKeyPoint in tourKeyPoints)
            {
                CheckpointDto tourKeyPointDto = new CheckpointDto
                {
                    Id = (int)tourKeyPoint.Id,
                    Name = tourKeyPoint.Name,
                    Description = tourKeyPoint.Description,
                    Image = tourKeyPoint.Image,
                    Latitude = tourKeyPoint.Latitude,
                    Longitude = tourKeyPoint.Longitude,
                    TourId = tourKeyPoint.TourId
                };
                tourKeyPointDtos.Add(tourKeyPointDto);
            }

            return tourKeyPointDtos;
        }

        public Result<List<CheckpointMobileDto>> GetByTourIdMobile(long tourId)
        {
            var checkpoints = _checkpointRepository.GetByTourId(tourId);
            List<CheckpointMobileDto> checkpointDtos = new List<CheckpointMobileDto>();

            foreach (var checkpoint in checkpoints)
            {
                var quizResult = _quizMobileInternalService.GetQuestionsByCheckpointId((int)checkpoint.Id);
                if (quizResult.IsFailed)
                {             
                    var checkpointMobileDtoWithoutQuiz = new CheckpointMobileDto
                    {
                        Id = checkpoint.Id,
                        Name = checkpoint.Name,
                        Description = checkpoint.Description,
                        Latitude = checkpoint.Latitude,
                        Longitude = checkpoint.Longitude,
                        Questions = new List<TourModuleQuizMobileDto>(), 
                        AchievementMobileDto = null
                    };

                    checkpointDtos.Add(checkpointMobileDtoWithoutQuiz);
                    continue;
                }

                var quizAchievementMobileDto = quizResult.Value;
            
                var achievementMobileDto = quizAchievementMobileDto.Achievement != null
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
             
                var questions = quizAchievementMobileDto.Questions != null
                    ? quizAchievementMobileDto.Questions.Select(q => new TourModuleQuizMobileDto
                    {
                        QuestionId = q.QuestionId,
                        Question = q.Question,
                        Answers = q.Answers != null
                            ? q.Answers.Select(a => new TourModuleAnswerMobileDto
                            {
                                QuestionId = a.QuestionId,
                                Answer = a.Answer,
                                IsTrue = a.IsTrue
                            }).ToList()
                            : new List<TourModuleAnswerMobileDto>()
                    }).ToList()
                    : new List<TourModuleQuizMobileDto>();

                var checkpointMobileDto = new CheckpointMobileDto
                {
                    Id = checkpoint.Id,
                    Name = checkpoint.Name,
                    Description = checkpoint.Description,
                    Latitude = checkpoint.Latitude,
                    Longitude = checkpoint.Longitude,
                    Questions = questions,
                    AchievementMobileDto = achievementMobileDto
                };

                checkpointDtos.Add(checkpointMobileDto);
            }

            return Result.Ok(checkpointDtos);
        }

        public Result<List<CheckpointMobileDto>> GetByCheckpointIdMobile(int checkpointId)
        {           
            var checkpoint = _checkpointRepository.GetById(checkpointId);

            if (checkpoint == null)
            {
                return Result.Fail<List<CheckpointMobileDto>>("No checkpoint found with the given ID.");
            }

            var quizResult = _quizMobileInternalService.GetQuestionsByCheckpointId(checkpointId);

            var quizAchievementMobileDto = new EncounterModuleQuizAchievementMobileDto
            {
                Questions = new List<EncounterModuleQuizMobileDto>(),
                Achievement = null
            };

            if (quizResult.IsSuccess)
            {
                quizAchievementMobileDto = quizResult.Value;
            }
          
            var achievementMobileDto = quizAchievementMobileDto.Achievement != null
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
        
            var questions = quizAchievementMobileDto.Questions != null
                ? quizAchievementMobileDto.Questions.Select(q => new TourModuleQuizMobileDto
                {
                    QuestionId = q.QuestionId,
                    Question = q.Question,
                    Answers = q.Answers != null
                        ? q.Answers.Select(a => new TourModuleAnswerMobileDto
                        {
                            QuestionId = a.QuestionId,
                            Answer = a.Answer,
                            IsTrue = a.IsTrue
                        }).ToList()
                        : new List<TourModuleAnswerMobileDto>()
                }).ToList()
                : new List<TourModuleQuizMobileDto>();
         
            var checkpointMobileDto = new CheckpointMobileDto
            {
                Id = checkpoint.Id,
                Name = checkpoint.Name,
                Description = checkpoint.Description,
                Latitude = checkpoint.Latitude,
                Longitude = checkpoint.Longitude,
                Questions = questions,
                AchievementMobileDto = achievementMobileDto
            };

            return Result.Ok(new List<CheckpointMobileDto> { checkpointMobileDto });
        }

    }
}
