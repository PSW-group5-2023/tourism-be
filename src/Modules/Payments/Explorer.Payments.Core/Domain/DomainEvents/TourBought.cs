using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Domain.DomainEvents
{
    public class TourBought : DomainEvent
    {
        public DateTime DateOfBuying { get; private set; }
        public TourBought(long Id, DateTime dateOfBuying) : base(Id)
        {
            DateOfBuying = dateOfBuying;
        }
    }
}
