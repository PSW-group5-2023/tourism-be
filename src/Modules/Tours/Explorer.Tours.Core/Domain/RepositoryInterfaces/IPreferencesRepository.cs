using Explorer.Tours.Core.Domain.Tours;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IPreferencesRepository
    {
        Preferences? GetByUserId(long userId); 
    }
}
