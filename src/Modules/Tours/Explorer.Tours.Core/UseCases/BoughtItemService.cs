using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases
{
    public class BoughtItemService : BaseService<BoughtItemDto,BoughtItem>, IBoughtItemService
    {
        private IBoughtItemRepository shoppingCartRepository;

        public BoughtItemService(IMapper mapper,IBoughtItemRepository shoppingCartRepository) : base(mapper)
        {
            this.shoppingCartRepository = shoppingCartRepository;
        }


        public Result<List<TourDto>> GetItemsByUserId(long userId)
        {
            List<Tour> items = new List<Tour>();
            List<TourDto> itemsDto = new List<TourDto>();
            items = shoppingCartRepository.GetItemsByUserId(userId);
            foreach (Tour tour in items)
            {
                TourDto dto = new TourDto
                {
                   Id = (int)tour.Id, Name = tour.Name, AuthorId= tour.AuthorId, Description= tour.Description,
                    Difficulty= (int)tour.Difficulty, Equipment= tour.Equipment, Price= tour.Price, Status= (int)tour.Status, Tags = tour.Tags, ArchivedDate = tour.ArchivedDate, DistanceInKm= tour.DistanceInKm


                };
                itemsDto.Add(dto);
            }

            return itemsDto;


        }

        public Result Create(List<BoughtItemDto> items)
        {
            {
                try
                {
                    foreach(var item in items) 
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

    }
}
