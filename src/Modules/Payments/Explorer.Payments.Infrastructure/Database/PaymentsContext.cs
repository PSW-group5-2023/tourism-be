﻿using Explorer.Payments.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Infrastructure.Database
{
    public class PaymentsContext : DbContext
    {
        public DbSet<BoughtItem> BoughtItems { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Wallet> Wallet { get; set; }

        public PaymentsContext(DbContextOptions<PaymentsContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("payments");
        }
    }
}
