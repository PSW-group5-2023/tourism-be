using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Encounters.Core.UseCases
{
    public class EncounterExecutionService : CrudService<EncounterExecutionDto, EncounterExecution>, IEncounterExecutionService
    {
        private readonly IEncounterExecutionRepository _encounterExecutionRepository;
        private readonly IMapper _mapper;

        public EncounterExecutionService(IEncounterExecutionRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _encounterExecutionRepository = repository;
            _mapper = mapper;
        }


        public Result<EncounterExecutionDto> SetCompletionTime(long touristId, long encounterId)
        {
            try
            {
                EncounterExecution encounterExecution = _encounterExecutionRepository.GetByTouristIdAndEncounterId(touristId, encounterId);
                encounterExecution.Complete();
                _encounterExecutionRepository.SaveChanges();

                return MapToDto(encounterExecution);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }


        public Result<EncounterExecutionDto> GetByTouristIdAndEnctounterId(long touristId, long encounterId)
        {
            try
            {
                var result = _encounterExecutionRepository.GetByTouristIdAndEncounterId(touristId, encounterId);
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<PagedResult<EncounterExecutionDto>> GetAllActiveByEncounterId(long encounterId)
        {
            try
            {
                var result = _encounterExecutionRepository.GetAllActiveByEncounterId(encounterId);
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<EncounterExecutionDto> SetInRange(long encounterId, long touristId, bool inRange)
        {
            try
            {
                var encounterExecution = _encounterExecutionRepository.GetByTouristIdAndEncounterId(touristId, encounterId);
                encounterExecution.InRange = inRange;
                _encounterExecutionRepository.SaveChanges();
                return MapToDto(encounterExecution);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<EncounterExecutionDto> CalculateCorrectAnswersPercentage(long touristId, List<SubmittedAnswerDto> answers, EncounterDto encounterDto)
        {
            try
            {
                var encounterExecution = _encounterExecutionRepository.GetByTouristIdAndEncounterId(touristId, encounterDto.Id);

                encounterExecution.SetCorrectAnswersPercentage(CalculatePercentage(answers, encounterDto.Questions));
                encounterExecution.SetAnswers(_mapper.Map<List<SubmittedAnswer>>(answers));

                _encounterExecutionRepository.SaveChanges();
                
                return MapToDto(encounterExecution);
            }
            catch(KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        private double CalculatePercentage(ICollection<SubmittedAnswerDto> answers, ICollection<QuestionDto> questions)
        {
            if (questions.Count != answers.Count) throw new ArgumentException("There is more/less answers than questions.");

            double correctAnswersCounter = 0;

            correctAnswersCounter = answers.Count(answer =>
                questions.Any(question =>
                    question.OrderInQuiz == answer.OrderInQuiz &&
                    question.Answers.Any(qAnswer =>
                        qAnswer.Content.Equals(answer.Content) && qAnswer.Correct
                    )
                )
            );

            return (correctAnswersCounter/questions.Count)*100;
        }
    }
}
