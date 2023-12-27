using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Domain.DomainEvents
{
    public class CouponUsed : DomainEvent
    {
        public DateTime DateOfUsing { get; private set; }
        public CouponUsed(long Id, DateTime dateOfUsing) : base(Id)
        {
            DateOfUsing = dateOfUsing;
        }
    }    
}
