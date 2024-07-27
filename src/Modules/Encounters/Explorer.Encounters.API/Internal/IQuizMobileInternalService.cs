using Explorer.Encounters.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Internal
{
    public interface IQuizMobileInternalService
    {
        Result<List<QuestionDto>> GetAllByEncounterId(long encounterId);
        Result<QuizTouristMobileDto> GetQuestionsByCheckpointId(int checkpointId);
       
    }
}
