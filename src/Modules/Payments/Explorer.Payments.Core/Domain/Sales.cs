﻿using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Domain
{
    public class Sales : Entity
    {
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public decimal DiscountPercentage { get; init; }

        private List<int> DiscountedTours = new List<int>();

        public Sales(DateTime startDate, DateTime endDate, decimal discountPercentage, List<int> discountedTours)
        {
            StartDate = startDate;
            EndDate = endDate;
            DiscountPercentage = discountPercentage;
            DiscountedTours = discountedTours;
        }
    }
}