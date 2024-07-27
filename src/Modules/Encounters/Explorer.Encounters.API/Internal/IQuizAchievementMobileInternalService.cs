using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Dtos.Tourist;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Internal
{
    public interface IQuizAchievementMobileInternalService
    {
        Result<List<QuestionDto>> GetAllByEncounterId(long encounterId);
        Result<EncounterModuleQuizAchievementMobileDto> GetQuestionsByCheckpointId(int checkpointId);
       
    }
}
