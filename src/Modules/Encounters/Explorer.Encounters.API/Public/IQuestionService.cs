using Explorer.Encounters.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Public
{
    public interface IQuestionService
    {
        Result<QuestionDto> Update(QuestionDto questionDto);
        Result<QuestionDto> Create(QuestionDto questionDto);
        Result Delete(int id);
        Result<List<QuestionDto>> GetAllByEncounterId(long encounterId);
    }
}
