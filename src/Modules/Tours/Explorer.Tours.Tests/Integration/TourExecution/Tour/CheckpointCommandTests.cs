using Explorer.API.Controllers.Tourist;
using Explorer.Tours.API.Dtos.Tour.Tourist;
using Explorer.Tours.API.Public.Tour;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Tests.Integration.TourExecution.Tour
{
    public class CheckpointCommandTests : BaseToursIntegrationTest
    {
        public CheckpointCommandTests(ToursTestFactory factory) : base(factory)
        {
        }
    }
}
