using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class UserNewsService : CrudService<UserNewsDto, UserNews>, IUserNewsService
    {
        public IUserNewsRepository _userNewsRepository;
        public UserNewsService(ICrudRepository<UserNews> crudRepository, IMapper mapper, IUserNewsRepository userNewsRepository) : base(crudRepository, mapper)
        {
            _userNewsRepository = userNewsRepository;
        }

        public Result<UserNewsDto> GetByTouristId(int touristId)
        {
            try
            {
                return MapToDto(_userNewsRepository.GetByTouristId(touristId));
            }
            catch(Exception e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }
    }
}
