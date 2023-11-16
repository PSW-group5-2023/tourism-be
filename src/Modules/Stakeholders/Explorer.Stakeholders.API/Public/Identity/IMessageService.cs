using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;

namespace Explorer.Stakeholders.API.Public.Identity
{
    public interface IMessageService
    {
        Result<MessageDto> Create(MessageDto message);
        Result<PagedResult<MessageDto>> GetMessagesByUserId(int page, int pageSize, long id);
    }
}
