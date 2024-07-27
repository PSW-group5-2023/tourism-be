using AutoMapper;
using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Internal;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Internal;
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
    public class QuizAchievementMobileInternalService : BaseService<QuestionDto, Question>, IQuizAchievementMobileInternalService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IEncounterRepository _encounterRepository;
        private readonly IAchievementTouristInternalService _achievementTouristInternalService;

        public QuizAchievementMobileInternalService(IQuestionRepository questionRepository, IMapper mapper, IEncounterRepository encounterRepository, IAchievementTouristInternalService achievementTouristInternalService) : base(mapper)
        {
            _questionRepository = questionRepository;
            _encounterRepository = encounterRepository;
            _achievementTouristInternalService = achievementTouristInternalService;
        }
        public Result<List<QuestionDto>> GetAllByEncounterId(long encounterId)
        {
            return MapToDto(_questionRepository.GetAllByEncounterId(encounterId, 0, 0).Results).Value;
        }

        public Result<QuizTouristMobileDto> GetQuestionsByCheckpointId(int checkpointId)
        {
            var encounterResult = GetEncounterByCheckpointId(checkpointId);

            if (encounterResult.IsFailed)
            {
                return Result.Fail<QuizTouristMobileDto>(encounterResult.Errors);
            }

            var encounter = encounterResult.Value;

            var questionDtosResult = GetAllByEncounterId(encounter.Id);
            if (questionDtosResult.IsFailed)
            {
                // Vratite grešku ili obradite neuspeh
                return Result.Fail<QuizTouristMobileDto>(questionDtosResult.Errors);
            }

            List<QuestionDto> questionDtos = questionDtosResult.Value;
            List<QuizQuestionMobileDto> questions = new List<QuizQuestionMobileDto>();

            foreach (QuestionDto question in questionDtos)
            {
                QuizQuestionMobileDto quizQuestionTouristDto = new QuizQuestionMobileDto(question);
                quizQuestionTouristDto.Answers.ForEach(answer => { answer.QuestionId = question.Id; });
                questions.Add(quizQuestionTouristDto);
            }

            QuizTouristMobileDto quizTouristDto = new QuizTouristMobileDto
            {
                Questions = questions,
                Achievement = TouristAchievementToMobile(GetAchievement(Convert.ToInt32(encounter.AchievementId)))
            };

            return Result.Ok(quizTouristDto);
        }

        public AchievementTouristMobileDto GetAchievement(int id)
        {
            return _achievementTouristInternalService.GetAchievementById(id).Value;
        }

        public AchievementMobileDto TouristAchievementToMobile(AchievementTouristMobileDto achievementTouristDto)
        {
            AchievementMobileDto achievementMobile = new AchievementMobileDto();
            achievementMobile.Id = achievementTouristDto.Id;
            achievementMobile.Rarity = achievementTouristDto.Rarity;
            achievementMobile.CraftingRecipe = achievementTouristDto.CraftingRecipe;
            achievementMobile.Description = achievementTouristDto.Description;
            achievementMobile.Icon = achievementTouristDto.Icon;
            achievementMobile.Name = achievementTouristDto.Name;
            return achievementMobile;
        }

        public Result<EncounterDto> GetEncounterByCheckpointId(int checkPointId)
        {
            var encounter = _encounterRepository.GetByCheckpointId(checkPointId);
            if (encounter == null)
            {
                // Vratite grešku ili prazan rezultat ako encounter nije pronađen
                return Result.Fail<EncounterDto>("No encounter found for the given checkpoint ID");
            }

            var encounterDto = new EncounterDto
            {
                Id = encounter.Id,
                CreatorId = encounter.CreatorId,
                Description = encounter.Description,
                Name = encounter.Name,
                Status = (int)encounter.Status,
                Latitude = encounter.Latitude,
                Longitude = encounter.Longitude,
                Type = (int)encounter.Type,
                ExperiencePoints = encounter.ExperiencePoints,
                IsMandatory = encounter.IsMandatory,
                AchievementId = encounter.AchievementId,
                CheckpointId = encounter.CheckpointId,
                LocationLatitude = null,
                LocationLongitude = null,
                RangeInMeters = null,
                RequiredAttendance = null,
                Questions = new List<QuestionDto>()
            };

            return Result.Ok(encounterDto);
        }

    }
}
