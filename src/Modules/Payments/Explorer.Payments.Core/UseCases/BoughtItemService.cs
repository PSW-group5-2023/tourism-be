using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Tours.API.Internal;

namespace Explorer.Payments.Core.UseCases
{
    public class BoughtItemService : BaseService<BoughtItemDto, BoughtItem>, IBoughtItemService
    {
        private readonly IMapper mapper;
        private IBoughtItemRepository shoppingCartRepository;
        private IInternalTourService internalTourUsageService;

        public BoughtItemService(IMapper mapper, IBoughtItemRepository shoppingCartRepository, IInternalTourService internalTourUsageService) : base(mapper)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.internalTourUsageService = internalTourUsageService;
            this.mapper = mapper;
        }


        public Result<List<ListedTourDto>> GetUnusedTours(int userId)
        {
            List<ListedTourDto> tourDtos = new List<ListedTourDto>();
            foreach (BoughtItem item in shoppingCartRepository.GetAllByUserId(userId))
            {
                if (!item.IsUsed)
                {
                    var result = internalTourUsageService.Get(item.TourId);
                    if (result.IsFailed) return Result.Fail(result.Errors);
                    tourDtos.Add(mapper.Map<ListedTourDto>(result.Value));
                }
            }

            return tourDtos;
        }

        public Result<List<ListedTourDto>> GetUsedTours(int userId)
        {
            List<ListedTourDto> tourDtos = new List<ListedTourDto>();
            foreach (BoughtItem item in shoppingCartRepository.GetAllByUserId(userId))
            {
                if (item.IsUsed)
                {
                    var result = internalTourUsageService.Get(item.TourId);
                    if (result.IsFailed) return Result.Fail(result.Errors);
                    tourDtos.Add(mapper.Map<ListedTourDto>(result.Value));
                }
            }

            return tourDtos;
        }

        public Result Create(List<BoughtItemDto> items)
        {
            {
                try
                {
                    foreach (var item in items)
                        shoppingCartRepository.AddToCart(MapToDomain(item));
                }
                catch (Exception e)
                {
                    return Result.Fail(FailureCode.NotFound).WithError(e.Message);
                }

                return Result.Ok();
            }
        }

        public Result DeleteItem(long tourId, long userId)
        {
            try
            {
                shoppingCartRepository.DeleteItem(tourId, userId);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }

            return Result.Ok();
        }

        public Result UpdateItem(long userId, long tourId)
        {
            try
            {
                shoppingCartRepository.GetItemToUpdate(userId, tourId);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }

            return Result.Ok();
        }
    }
}
