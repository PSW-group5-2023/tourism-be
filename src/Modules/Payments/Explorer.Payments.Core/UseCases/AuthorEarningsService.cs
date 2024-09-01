using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.DomainServicesInterface;
using Explorer.Tours.API.Internal;
using FluentResults;

namespace Explorer.Payments.Core.UseCases
{
    public class AuthorEarningsService : BaseService<AuthorEarningsDto, BoughtItem>, IAuthorEarningsService
    {
        private IInternalTourService _internalTourUsageService;
        private IBoughtItemService _boughtItemService;
        private IAuthorEarningsDomainService _authorEarningsDomainService;

        public AuthorEarningsService(IMapper mapper, IInternalTourService internalTourUsageService, IBoughtItemService boughtItemService, IAuthorEarningsDomainService authorEarningsDomainService) : base(mapper)
        {
            _internalTourUsageService = internalTourUsageService;
            _boughtItemService = boughtItemService;
            _authorEarningsDomainService = authorEarningsDomainService;
        }

        public Result<PagedResult<AuthorEarningsDto>> CalculateEarningsByTours(long authorId)
        {
            
            var list= _authorEarningsDomainService.CalculateEarningsByTours(authorId);
            PagedResult<AuthorEarningsDto> authorEarningsDtos = new PagedResult<AuthorEarningsDto>(new List<AuthorEarningsDto>(), 0);
            foreach(var l in list.Value)
            {
                AuthorEarningsDto authorEarningsDto=new AuthorEarningsDto(l.AuthorId,l.Earning,l.TourId,l.TourName);
                authorEarningsDtos.Results.Add(authorEarningsDto);
            }
            return authorEarningsDtos;
        }

        public Result<double> CalculateTotalEarnings(long authorId)
        {
            return _authorEarningsDomainService.CalculateTotalEarnings(authorId);
        }
    }
}
