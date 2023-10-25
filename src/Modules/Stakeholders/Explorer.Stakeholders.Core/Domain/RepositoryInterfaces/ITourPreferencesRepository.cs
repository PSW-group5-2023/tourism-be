
using Explorer.Stakeholders.Core.Domain;

namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface ITourPreferencesRepository
    {
        TourPreferences? GetByUserId(long userId); 
    }
}
