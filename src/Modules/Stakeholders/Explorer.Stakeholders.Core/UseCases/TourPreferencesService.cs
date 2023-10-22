using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases;
public class TourPreferencesService : CrudService<TourPreferencesDto, TourPreferences>, ITourPreferencesService
{
    private readonly ITourPreferencesRepository _preferencesRepository;
    private readonly IMapper _mapper;
    public TourPreferencesService(ICrudRepository<TourPreferences> repository, ITourPreferencesRepository preferencesRepository, IMapper mapper) : base(repository, mapper) {
        _preferencesRepository = preferencesRepository;
        _mapper = mapper;
    }

    public Result<TourPreferencesDto> GetByUserId(long userId)
    {
        var result = _preferencesRepository.GetByUserId(userId);
        return MapToDto(result);
    }
}

