﻿using Explorer.BuildingBlocks.Core.UseCases;
using AutoMapper;
using FluentResults;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.Core.Domain.Tours;

namespace Explorer.Tours.Core.UseCases.Tours
{
    public class PublicTourKeyPointService : CrudService<PublicTourKeyPointDto, PublicTourKeyPoints>, IPublicTourKeyPointService
    {
        private readonly ITourKeyPointsRepository _tourKeyPointsRepository;
        public PublicTourKeyPointService(ICrudRepository<PublicTourKeyPoints> crudRepository, IMapper mapper, ITourKeyPointsRepository tourKeyPointsRepository) : base(crudRepository, mapper)
        {
            _tourKeyPointsRepository = tourKeyPointsRepository;
        }

        public Result<PublicTourKeyPointDto> ChangeStatus(int id, string status)
        {
            PublicTourKeyPoints keyPoint = (PublicTourKeyPoints)_tourKeyPointsRepository.GetById(id);
            switch (status)
            {
                case "Approved":
                    keyPoint.ChangeStatus(PublicTourKeyPoints.PublicTourKeyPointStatus.Approved);
                    break;
                case "Denied":
                    keyPoint.ChangeStatus(PublicTourKeyPoints.PublicTourKeyPointStatus.Denied);
                    break;
                default:
                    throw new ArgumentException("Invalid status", nameof(status));

            }
            _tourKeyPointsRepository.Update(keyPoint);


            return CreateDto(keyPoint);
        }

        private PublicTourKeyPointDto CreateDto(PublicTourKeyPoints keyPoint)
        {
            return new PublicTourKeyPointDto
            {
                Id = (int)keyPoint.Id,
                Name = keyPoint.Name,
                Description = keyPoint.Description,
                Image = keyPoint.Image,
                Latitude = keyPoint.Latitude,
                Longitude = keyPoint.Longitude,
                CreatorId = keyPoint.CreatorId,
                Status = keyPoint.Status.ToString(),
            };
        }
        public Result<List<PublicTourKeyPointDto>> GetByStatus(string status)
        {
            List<PublicTourKeyPointDto> tourKeyPointDtos = new List<PublicTourKeyPointDto>();
            Enum.TryParse(status, out PublicTourKeyPoints.PublicTourKeyPointStatus parsedStatus);
            var tourKeyPoints = _tourKeyPointsRepository.GetByStatus(parsedStatus);
            foreach (var tourKeyPoint in tourKeyPoints)
            {
                tourKeyPointDtos.Add(CreateDto(tourKeyPoint));
            }

            return tourKeyPointDtos;
        }

    }
}
