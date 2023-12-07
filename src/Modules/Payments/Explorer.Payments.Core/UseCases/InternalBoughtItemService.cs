using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Internal;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.UseCases
{
    public class InternalBoughtItemService : BaseService<BoughtItemDto, BoughtItem>, IInternalBoughtItemService
    {
        public IInternalBoughtItemDatabaseRepository _internalBoughtItemDatabaseRepository;

        public InternalBoughtItemService(IInternalBoughtItemDatabaseRepository internalBoughtItemDatabaseRepository, IMapper mapper) : base(mapper)
        {
            _internalBoughtItemDatabaseRepository = internalBoughtItemDatabaseRepository;
        }


        public Result<BoughtItemDto> CreateBoughtItem(BoughtItemDto boughtItemDto)
        {
            try
            {
                _internalBoughtItemDatabaseRepository.CreateBoughtItem(MapToDomain(boughtItemDto));
            }
            catch (Exception e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }

            return Result.Ok();
        }
    }
}
