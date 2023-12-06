﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Payments.API.Internal;
using Explorer.Payments.API.Public;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Explorer.Payments.Core.Mappers;
using Explorer.Payments.Core.UseCases;
using Explorer.Payments.Infrastructure.Database;
using Explorer.Payments.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Infrastructure
{
    public static class PaymentsStartup
    {
        public static IServiceCollection ConfigurePaymentsModule(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PaymentsProfile).Assembly);
            SetupCore(services);
            SetupInfrastructure(services);
            return services;
        }

        private static void SetupCore(IServiceCollection services)
        {
            services.AddScoped<IBoughtItemService, BoughtItemService>();
            services.AddScoped<IInternalBoughtItemService, InternalBoughtItemService>();
        }

        private static void SetupInfrastructure(IServiceCollection services)
        {
            services.AddScoped<IBoughtItemRepository, BoughtItemDatabaseRepository>();
            services.AddScoped<IInternalBoughtItemDatabaseRepository, InternalBoughtItemDatabaseRepository>();

            services.AddDbContext<PaymentsContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("payments"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "payments")));
        }
    }
}
