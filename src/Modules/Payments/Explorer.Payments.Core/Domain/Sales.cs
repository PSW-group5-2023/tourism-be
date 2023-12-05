using Explorer.BuildingBlocks.Core.Domain;
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
        public float DiscountPercentage { get; init; }

        //private List<int> DiscountedTours = new List<int>();

        public Sales(DateTime startDate, DateTime endDate, float discountPercentage)
        {
            StartDate = startDate.ToUniversalTime();
            EndDate = endDate.ToUniversalTime();
            DiscountPercentage = discountPercentage;
            //DiscountedTours = discountedTours;
        }
    }
}
