using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class BoughtItem : Entity
    {

        public long UserId { get; init; }
        public long TourId { get; init; }        
        public DateTime? DateOfBuying { get; init; }

        public BoughtItem(long userId, long tourId)
        {
            UserId = userId;
            TourId = tourId;
            DateOfBuying = DateTime.UtcNow;
        }
    }
}
