﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ITourProblemRepository
    {
        List<TourProblem> GetByTouristId(long touristId);
        List<TourProblem> GetByTourId(long tourId);

    }
}
