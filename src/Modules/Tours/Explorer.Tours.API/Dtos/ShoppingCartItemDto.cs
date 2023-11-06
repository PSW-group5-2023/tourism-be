﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class ShoppingCartItemDto
    {
        public long Id { get; set; }
        public long ShoppingCartId { get; set; }
        public long TourId { get; set; }
        public TourDto Tour { get; set; } = new TourDto();
                
    }
}
