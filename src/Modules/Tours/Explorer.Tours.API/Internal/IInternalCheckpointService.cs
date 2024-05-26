using Explorer.Tours.API.Dtos.Tour;
using FluentResults;

namespace Explorer.Tours.API.Internal
{
    public interface IInternalCheckpointService
    {
        Result<CheckpointDto> Get(long id);
        Result<bool> CheckIfUserIsAuthor(long authorId, long keypointId);
    }
}
