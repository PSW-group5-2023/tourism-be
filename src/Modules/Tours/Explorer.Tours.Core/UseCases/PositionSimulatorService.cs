﻿using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases
{
    public class PositionSimulatorService : CrudService<PositionSimulatorDto, PositionSimulator>, IPositionSimulatorService 
    {
        public PositionSimulatorService(ICrudRepository<PositionSimulator> repository, IMapper mapper) : base(repository, mapper) { }
    }

}
