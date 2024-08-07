﻿using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Internal;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;

namespace Explorer.Tours.Core.UseCases.Tours
{
    public class InternalCheckpointService : BaseService<CheckpointDto, Checkpoint>, IInternalCheckpointService
    {
        public ICheckpointRepository _checkpointRepository;
        public ITourService _tourService;

        public InternalCheckpointService(ICheckpointRepository checkpointRepository, ITourService tourService, IMapper mapper) : base(mapper)
        {
            _checkpointRepository = checkpointRepository;
            _tourService = tourService;
        }

        public Result<CheckpointDto> Get(long id)
        {
            return MapToDto(_checkpointRepository.Get(id));
        }

        public Result<bool> CheckIfUserIsAuthor(long authorId, long keypointId)
        {
            Checkpoint checkpoint = _checkpointRepository.Get(keypointId);

            if (checkpoint.TourId != null)
            {
                TourDto tourDto = _tourService.GetById((long)checkpoint.TourId).Value;
                return authorId == tourDto.AuthorId;
            }
            return false;
        }
    }
}
