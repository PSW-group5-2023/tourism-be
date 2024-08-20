using Explorer.BuildingBlocks.Core.UseCases;
using AutoMapper;
using FluentResults;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.Core.Domain.Tours;

namespace Explorer.Tours.Core.UseCases.Tours
{
    public class PublicCheckpointsService : CrudService<PublicCheckpointDto, PublicCheckpoint>, IPublicCheckpointService
    {
        private readonly IPublicCheckpointRepository _publicCheckpointRepository;
        private readonly IMapper _mapper;
        public PublicCheckpointsService(ICrudRepository<PublicCheckpoint> crudRepository, IMapper mapper, IPublicCheckpointRepository publicCheckpointRepository) : base(crudRepository, mapper)
        {
            _publicCheckpointRepository = publicCheckpointRepository;
            _mapper = mapper;
        }

        public Result<PublicCheckpointDto> ChangeStatus(int id, string status)
        {
            PublicCheckpoint checkpoint = (_publicCheckpointRepository.GetById(id));
            if (checkpoint == null) return Result.Fail(FailureCode.InvalidArgument).WithError("Checkpoint not found.");

            switch (status)
            {
                case "Approved":
                    checkpoint.ChangeStatus(PublicCheckpointStatus.Approved);
                    break;
                case "Denied":
                    checkpoint.ChangeStatus(PublicCheckpointStatus.Denied);
                    break;
                default:
                    throw new ArgumentException("Invalid status", nameof(status));

            }
            _publicCheckpointRepository.Update(checkpoint);

            return MapToDto(checkpoint);
        }

        public Result<List<PublicCheckpointDto>> GetByStatus(string status)
        {
            if(!Enum.TryParse(status, out PublicCheckpointStatus parsedStatus))
            {
                return Result.Fail(FailureCode.Internal).WithError("Error while parsing public checkpoint status.");
            }
            var checkpoints = _publicCheckpointRepository.GetByStatus(parsedStatus);

            var publicCheckpointDtos = _mapper.Map<List<PublicCheckpointDto>>(checkpoints);

            return publicCheckpointDtos;
        }

    }
}
