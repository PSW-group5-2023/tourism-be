using FluentResults;
using Explorer.Stakeholders.API.Dtos;

namespace Explorer.Tours.API.Internal
{
    public interface IInternalPersonService
    {
        Result<PersonDto> Get(int id);
        Result<string> GetEmailByUserId(int id);
        Result<string> GetNameById(int id);
    }
}
