using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public.Identity;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Stakeholders.Core.UseCases.Identity
{
    public class MessageService : BaseService<MessageDto, Message>, IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMapper mapper, IMessageRepository messageRepository) : base(mapper)
        {
            _messageRepository = messageRepository;
        }

        public Result<MessageDto> Create(MessageDto message)
        {
            try
            {
                var result = _messageRepository.Create(MapToDomain(message));
                return MapToDto(result);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result<PagedResult<MessageDto>> GetMessagesByUserId(int page, int pageSize, long id)
        {
            var result = _messageRepository.GetPaged(page, pageSize);
            return MapToDto(result);
        }
    }
}
