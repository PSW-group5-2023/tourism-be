using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public
{
    public interface IJoinRequestService
    {
        Result<JoinRequestDto> Create(JoinRequestDto club);
        Result<JoinRequestDto> Update(JoinRequestDto club);
        Result<List<JoinRequestDto>> FindRequests(long ownerId); // its going to be one of those 2 parameters probably?
        Result Delete(int id);


    }
}
