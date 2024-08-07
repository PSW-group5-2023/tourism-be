﻿using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;


namespace Explorer.Tours.Core.UseCases.Tours;
public class PreferencesService : CrudService<PreferencesDto, Preferences>, IPreferencesService
{
    private readonly IPreferencesRepository _preferencesRepository;
    private readonly IMapper _mapper;
    public PreferencesService(ICrudRepository<Preferences> repository, IPreferencesRepository preferencesRepository, IMapper mapper) : base(repository, mapper)
    {
        _preferencesRepository = preferencesRepository;
        _mapper = mapper;
    }

    public Result<PreferencesDto> GetByUserId(long userId)
    {
        var result = _preferencesRepository.GetByUserId(userId);
        return MapToDto(result);
    }
}

