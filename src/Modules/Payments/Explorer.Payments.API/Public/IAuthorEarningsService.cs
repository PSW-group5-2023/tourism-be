﻿using Explorer.Payments.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.API.Public
{
    public interface IAuthorEarningsService
    {
        public Result<List<AuthorEarningsDto>> CalculateEarningsByTours(long authorId); 
        public Result<double> CalculateTotalEarnings(long authorId);
    }
}
