using AutoMapper;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.Core.Domain;

namespace Explorer.Encounters.Core.Mappers
{
    public class EncounterProfile : Profile
    {
        public EncounterProfile()
        {
            CreateMap<ChallengeDto, Challenge>().ReverseMap();
            CreateMap<ChallengeExecutionDto, ChallengeExecution>().ReverseMap();
            CreateMap<UserExperienceDto, UserExperience>().ReverseMap();
            CreateMap<EncounterDto, Encounter>().ReverseMap();
            CreateMap<EncounterDto, LocationEncounter>().ReverseMap();
            CreateMap<EncounterDto, SocialEncounter>().ReverseMap();
            CreateMap<EncounterExecutionDto, EncounterExecution>().ReverseMap();
        }
    }
}
