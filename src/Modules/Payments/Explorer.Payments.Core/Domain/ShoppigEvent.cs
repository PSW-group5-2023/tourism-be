using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Payments.Core.Domain.DomainEvents;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Domain
{
    public class ShoppigEvent : EventSourcedAggregate
    {

        public long? TourId { get; private set; }
        public long? CouponId { get; private set; }

        public ShoppigEvent(long id, long? tourId, long? couponId)
        {
            Id = id;
            Changes = new List<DomainEvent>();
            TourId = tourId;
            CouponId = couponId;
        }

        public void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
        }

        private void When(TourBought tour)
        {
            Id = tour.Id;
            TourId = tour.Id;
        }

        private void When(CouponUsed coupon)
        {
            Id = coupon.Id;
            CouponId = coupon.Id;
        }

        private void Causes(DomainEvent @event)
        {
            Changes.Add(@event);
            Apply(@event);
        }

    }
}