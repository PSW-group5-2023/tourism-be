using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public.Identity;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases.Identity
{
    public class FollowerService : BaseService<FollowerDto, Follower>, IFollowerService
    {
        private readonly IFollowerRepository _followerRepository;
        public FollowerService(IFollowerRepository followerRepository, IMapper mapper) : base(mapper)
        {
            _followerRepository = followerRepository;
        }
        public Result<FollowerDto> Get(int id)
        {
            try
            {
                var result = _followerRepository.Get(id);
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }
        public Result<FollowerDto> Create(FollowerDto follower)
        {
            try
            {
                var result = _followerRepository.Create(MapToDomain(follower));
                return MapToDto(result);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result Delete(int followerId, int followedId)
        {
            try
            {
                _followerRepository.Delete(followerId, followedId);
                return Result.Ok();
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }
        
    }
}
