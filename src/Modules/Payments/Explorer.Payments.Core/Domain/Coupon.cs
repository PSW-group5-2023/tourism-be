using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Domain
{
    public class Coupon : Entity
    {
        public string Code { get; init; }
        public double Discount { get; init; }
        public DateTime? ExpirationDate { get; init; }
        public int? TourId { get; init; }
        public int AuthorId { get; init; }
        public bool IsUsed { get; init; }

        public Coupon(string code, double discount, DateTime? expirationDate, int? tourId, int authorId)
        {
            Code = code;
            Discount = discount;
            ExpirationDate = expirationDate;
            TourId = tourId;
            AuthorId = authorId;
            IsUsed = false;
        }
    }
}
