using AutoMapper;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.Core.Domain;

namespace Explorer.Encounters.Core.Mappers
{
    public class EncounterProfile : Profile
    {
        public EncounterProfile()
        {
            CreateMap<UserExperienceDto, UserExperience>().ReverseMap();
            CreateMap<EncounterDto, Encounter>().ReverseMap();
            CreateMap<EncounterDto, LocationEncounter>().ReverseMap();
            CreateMap<EncounterDto, SocialEncounter>()
            .ConstructUsing(dto => new SocialEncounter(
                dto.CreatorId,
                dto.Description,
                dto.Name,
                (EncounterStatus)dto.Status,
                (EncounterType)dto.Type,
                dto.Latitude,
                dto.Longitude,
                dto.CheckpointId,
                dto.ExperiencePoints,
                dto.IsMandatory,
                dto.RangeInMeters ?? 0,
                dto.RequiredAttendance ?? 0))
            .ReverseMap();
            CreateMap<EncounterExecutionDto, EncounterExecution>().ReverseMap();
            CreateMap<EncounterDto, QuizEncounter>().ReverseMap();
            CreateMap<QuestionDto, Question>().ReverseMap();
            CreateMap<AnswerDto, Answer>().ReverseMap();
        }
    }
}
