using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;

namespace Explorer.Tours.Core.UseCases.Tours
{
    public class CheckpointService : CrudService<CheckpointDto, Checkpoint>, ICheckpointService
    {
        private readonly ICheckpointRepository _checkpointRepository;

        public CheckpointService(ICrudRepository<Checkpoint> repository, IMapper mapper, ICheckpointRepository checkpointRepository) : base(repository, mapper)
        {
            _checkpointRepository = checkpointRepository;
        }

        public Result<List<CheckpointDto>> GetByTourId(long tourId)
        {
            List<CheckpointDto> tourKeyPointDtos = new List<CheckpointDto>();
            var tourKeyPoints = _checkpointRepository.GetByTourId(tourId);
            foreach (var tourKeyPoint in tourKeyPoints)
            {
                CheckpointDto tourKeyPointDto = new CheckpointDto
                {
                    Id = (int)tourKeyPoint.Id,
                    Name = tourKeyPoint.Name,
                    Description = tourKeyPoint.Description,
                    Image = tourKeyPoint.Image,
                    Latitude = tourKeyPoint.Latitude,
                    Longitude = tourKeyPoint.Longitude,
                    TourId = tourKeyPoint.TourId
                };
                tourKeyPointDtos.Add(tourKeyPointDto);
            }

            return tourKeyPointDtos;
        }

    }
}
