using Explorer.BuildingBlocks.Core.UseCases;

namespace Explorer.Encounters.Core.Domain.RepositoryInterfaces
{
    public interface IUserExperienceRepository : ICrudRepository<UserExperience>
    {
        UserExperience GetByUserId(long userId);
    }
}
