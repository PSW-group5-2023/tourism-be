using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Payments.Core.Domain;

namespace Explorer.Payments.Core.UseCases
{
    public class BundleService : CrudService<BundleDto, Bundle>, IBundleService
    {
        
        public BundleService(ICrudRepository<Bundle> repository, IMapper mapper) : base(repository, mapper)
        {
        }

    }
}
