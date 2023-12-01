using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.API.Public
{
    public interface IBundleService
    {
        Result<PagedResult<BundleDto>> GetPaged(int page, int pageSize);
        Result<BundleDto> Create(BundleDto bundle);
        Result<BundleDto> Update(BundleDto bundle);
        Result Delete(int id);
    }
}
