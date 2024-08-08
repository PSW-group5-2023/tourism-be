using Explorer.BuildingBlocks.Core.UseCases;

namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface IMessageRepository
    {
        Message Create(Message message);
        PagedResult<Message> GetPaged(int page, int pageSize);
        void Delete(int messageId);

    }
}
