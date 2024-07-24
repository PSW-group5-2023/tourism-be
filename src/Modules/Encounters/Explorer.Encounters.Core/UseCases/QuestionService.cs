using AutoMapper;
using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Internal;
using Explorer.Achievements.Core.UseCases;
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
    public class QuestionService : CrudService<QuestionDto, Question>, IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IEncounterService _encounterService;
        private readonly IAchievementTouristInternalService _achievementTouristInternalService;
        private readonly IMapper _mapper;
        public QuestionService(IQuestionRepository questionRepository, IMapper mapper, IEncounterService encounterService, IAchievementTouristInternalService achievementTouristInternalService) : base(questionRepository, mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _encounterService = encounterService;
            _achievementTouristInternalService = achievementTouristInternalService;
        }

        public Result<List<QuestionDto>> GetAllByEncounterId(long encounterId)
        {
            return MapToDto(_questionRepository.GetAllByEncounterId(encounterId, 0, 0).Results).Value;
        }
        public Result<QuizTouristMobileDto> GetQuestionsByCheckpointId(int checkpointId)
        {
            var encounter = _encounterService.GetEncounterByCheckpointId(checkpointId).Value;
            List<QuestionDto> questionDtos = GetAllByEncounterId(encounter.Id).Value;
            List<QuizQuestionMobileDto> questions = new List<QuizQuestionMobileDto>();
            foreach (QuestionDto question in questionDtos)
            {
                QuizQuestionMobileDto quizQuestionTouristDto = new QuizQuestionMobileDto(question);
                quizQuestionTouristDto.Answers.ForEach(answer => { answer.QuestionId = question.Id; });
                questions.Add(quizQuestionTouristDto);
            }
            QuizTouristMobileDto quizTouristDto=new QuizTouristMobileDto();
            quizTouristDto.Questions= questions;
            quizTouristDto.Achievement = TouristAchievementToMobile(GetAchievement(Convert.ToInt32(encounter.AchievementId)));
            return quizTouristDto;
        }
        public AchievementTouristMobileDto GetAchievement(int id)
        {
            return _achievementTouristInternalService.GetAchievementById(id).Value;
        }
        public AchievementMobileDto TouristAchievementToMobile(AchievementTouristMobileDto achievementTouristDto)
        {
            AchievementMobileDto achievementMobile = new AchievementMobileDto();
            achievementMobile.Id = achievementTouristDto.Id;
            achievementMobile.Rarity= achievementTouristDto.Rarity;
            achievementMobile.CraftingRecipe = achievementTouristDto.CraftingRecipe;
            achievementMobile.Description= achievementTouristDto.Description;
            achievementMobile.Icon=achievementTouristDto.Icon;
            achievementMobile.Name= achievementTouristDto.Name;
            return achievementMobile;
        }
    }
}
