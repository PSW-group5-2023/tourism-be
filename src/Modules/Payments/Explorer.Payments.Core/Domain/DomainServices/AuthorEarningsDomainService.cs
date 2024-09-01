using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.DomainDtos;
using Explorer.Payments.Core.Domain.DomainServices;
using Explorer.Payments.Core.Domain.DomainServicesInterface;
using Explorer.Tours.API.Internal;
using FluentResults;
using System.Collections.Generic;

namespace Explorer.Payments.Core.UseCases
{
    public class AuthorEarningsDomainService: IAuthorEarningsDomainService
    {
        IBoughtItemDomainService _boughtItemDomainService;
        IInternalTourService _internalTourService;
        public AuthorEarningsDomainService(IBoughtItemDomainService boughtItemDomainService,IInternalTourService internalTourService)
        {
            _boughtItemDomainService = boughtItemDomainService;
            _internalTourService = internalTourService;
        }
        public Result<List<AuthorEarningsDomainDto>> CalculateEarningsByTours(long authorId)
        {
            List<AuthorEarningsDomainDto> dtos = new List<AuthorEarningsDomainDto>();
            List<BoughtItem> boughtItems = _boughtItemDomainService.GetAll().Value;
            foreach (var d in boughtItems)
            {
                var tour = _internalTourService.Get(Convert.ToInt32(d.TourId));
                AuthorEarningsDomainDto authorEarningsDto = new AuthorEarningsDomainDto();
                if (tour.Value.AuthorId == authorId)
                {
                    var alreadyExists = dtos.Find(a => a.TourId == tour.Value.Id);
                    double withDiscount = tour.Value.Price;
                    if (dtos.Contains(alreadyExists))
                    {
                        alreadyExists.Earning += withDiscount;
                    }
                    else
                    {
                        authorEarningsDto.Earning += withDiscount;
                        authorEarningsDto.TourId = tour.Value.Id;
                        authorEarningsDto.AuthorId = authorId;
                        authorEarningsDto.TourName = tour.Value.Name;
                        dtos.Add(authorEarningsDto);
                    }
                }
            }
            var allTours = _internalTourService.GetAllPagedByAuthorId(Convert.ToInt32(authorId));
            foreach (var tour in allTours.Value.Results)
            {
                if(!dtos.Contains(dtos.Find(d=>d.TourId==tour.Id)))
                {
                    AuthorEarningsDomainDto authorEarningsDto = new AuthorEarningsDomainDto();
                    authorEarningsDto.Earning = 0;
                    authorEarningsDto.TourId = tour.Id;
                    authorEarningsDto.AuthorId = authorId;
                    authorEarningsDto.TourName = tour.Name;
                    dtos.Add(authorEarningsDto);
                }
            }
            return dtos.ToResult();
        }
        public Result<double> CalculateTotalEarnings(long authorId)
        {
            var list = CalculateEarningsByTours(authorId);
            double totalEarnings = 0;
            foreach (var item in list.Value)
            {
                totalEarnings += item.Earning;
            }
            return totalEarnings.ToResult();
        }
    }
}
