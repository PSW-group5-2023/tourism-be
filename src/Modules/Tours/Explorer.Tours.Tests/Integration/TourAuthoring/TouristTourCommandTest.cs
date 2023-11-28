using Explorer.Blog.API.Dtos;
using Explorer.Blog.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.API.Controllers.Tourist;
using Explorer.Tours.API.Dtos.TouristTour;
using Explorer.Blog.API.Public;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.TouristTour;
using Explorer.Tours.Infrastructure.Database;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.TourAuthoring
{
    [Collection("Sequential")]
    public class TouristTourCommandTest : BaseToursIntegrationTest
    {
        public TouristTourCommandTest(ToursTestFactory factory) : base(factory)
        {

        }

        [Theory]
        [MemberData(nameof(TouristTourDtos))]
        public void Creation(TouristTourDto tourDto, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            var result = (ObjectResult)controller.Create(tourDto).Result;

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedResponseCode);

            // Assert - Database
            if (result.StatusCode != 400)
            {
            }


        }


        public static IEnumerable<object[]> TouristTourDtos()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new TouristTourDto
                    {
                        Id=-1,
                        Name = "TourName",
                        AuthorId = -1,
                        Description = "OpisTure",
                        DistanceInKm = 60,
                        KeyPoints = new List<TourKeyPointDto>()
                        {
                            new TourKeyPointDto
                            {
                                Id = -3329,
                                Latitude = 0,
                                Longitude = 0,
                                Description = "Opis tacke",
                                Image = new Uri("noviuri"),
                                Name = "Ime tacke",
                                PositionInTour = 1,
                            },
                            new TourKeyPointDto
                            {
                                Id = -3330,
                                Latitude = 0,
                                Longitude = 0,
                                Description = "Opis tacke",
                                Image = new Uri("noviuri"),
                                Name = "Ime tacke 2",
                                PositionInTour = 2,
                            },

                        }
                    },
                    200
                },
                new object[]
                {
                    new TouristTourDto
                    {
                        Id=-2,
                        Name = "",
                        AuthorId = -1,
                        Description = "",
                        DistanceInKm = 60,
                        KeyPoints = new List<TourKeyPointDto>()
                        {
                            new TourKeyPointDto
                            {
                                Id = -3331,
                                Latitude = 0,
                                Longitude = 0,
                                Description = "Opis tacke",
                                Image = new Uri("noviuri"),
                                Name = "Ime tacke",
                                PositionInTour = 1,
                            },
                            new TourKeyPointDto
                            {
                                Id = -3332,
                                Latitude = 0,
                                Longitude = 0,
                                Description = "Opis tacke",
                                Image = new Uri("noviuri"),
                                Name = "Ime tacke 2",
                                PositionInTour = 2,
                            },

                        }
                    },
                    400
                },
                new object[]
                {
                    new TouristTourDto
                    {
                        Id=-3,
                        Name = "Neki naziv",
                        AuthorId = -1,
                        Description = "",
                        DistanceInKm = 60,
                        KeyPoints = new List<TourKeyPointDto>()
                        {
                            new TourKeyPointDto
                            {
                                Id = -3333,
                                Latitude = 0,
                                Longitude = 0,
                                Description = "Opis tacke",
                                Image = new Uri("noviuri"),
                                Name = "Ime tacke",
                                PositionInTour = 1,
                            },
                            new TourKeyPointDto
                            {
                                Id = -3334,
                                Latitude = 0,
                                Longitude = 0,
                                Description = "Opis tacke",
                                Image = new Uri("noviuri"),
                                Name = "Ime tacke 2",
                                PositionInTour = 2,
                            },
                            new TourKeyPointDto
                            {
                                Id = -3335,
                                Latitude = 0,
                                Longitude = 0,
                                Description = "Opis tacke3",
                                Image = new Uri("noviuri"),
                                Name = "Ime tacke 3",
                                PositionInTour = 3,
                            },

                        }
                    },
                    200
                },
                new object[]
                {
                    new TouristTourDto
                    {
                        Id=-4,
                        Name = "Neki naziv",
                        AuthorId = -1,
                        Description = "",
                        DistanceInKm = 60,
                        KeyPoints = new List<TourKeyPointDto>()
                        {
                            new TourKeyPointDto
                            {
                                Id = -3336,
                                Latitude = 0,
                                Longitude = 0,
                                Description = "Opis tacke",
                                Image = new Uri("noviuri"),
                                Name = "Ime tacke",
                                PositionInTour = 1,
                            }

                        }
                    },
                    400
                },

                new object[]
                {
                    new TouristTourDto{
                        Id=-5,
                        Name = "TourName2",
                        AuthorId = -1,
                        Description = "OpisTure",
                        DistanceInKm = 50,
                        KeyPoints = new List<TourKeyPointDto>()
                    },
                    400
                }
            };
        }


        [Theory]
        [InlineData(-1, 200)]
        [InlineData(17900, 404)]
        public void DeleteTour(int tourId, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            var result = (ObjectResult)controller.Delete(tourId);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedResponseCode);

            // Assert - Database


        }

        [Theory]
        [MemberData(nameof(TouristTourDtosUpdate))]
        public void UpdateTour(TouristTourDto tourDto, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            var result = (ObjectResult)controller.Update(tourDto).Result;

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedResponseCode);

            // Assert - Database


        }


        public static IEnumerable<object[]> TouristTourDtosUpdate()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new TouristTourDto
                    {
                        Id=30000,
                        Name = "TourName",
                        AuthorId = -1,
                        Description = "OpisTure",
                        DistanceInKm = 60,
                        KeyPoints = new List<TourKeyPointDto>()
                        {
                            new TourKeyPointDto
                            {
                                Id = -3329,
                                Latitude = 0,
                                Longitude = 0,
                                Description = "Opis tacke",
                                Image = new Uri("noviuri"),
                                Name = "Ime tacke",
                                PositionInTour = 1,
                            },
                            new TourKeyPointDto
                            {
                                Id = -3330,
                                Latitude = 0,
                                Longitude = 0,
                                Description = "Opis tacke",
                                Image = new Uri("noviuri"),
                                Name = "Ime tacke 2",
                                PositionInTour = 2,
                            },

                        }
                    },
                    404
                },
                new object[]
                {
                    new TouristTourDto
                    {
                        Id=-3,
                        Name = "",
                        AuthorId = -1,
                        Description = "",
                        DistanceInKm = 60,
                        KeyPoints = new List<TourKeyPointDto>()
                        {
                            new TourKeyPointDto
                            {
                                Id = -3331,
                                Latitude = 0,
                                Longitude = 0,
                                Description = "Opis tacke",
                                Image = new Uri("noviuri"),
                                Name = "Ime tacke",
                                PositionInTour = 1,
                            },
                            new TourKeyPointDto
                            {
                                Id = -3332,
                                Latitude = 0,
                                Longitude = 0,
                                Description = "Opis tacke",
                                Image = new Uri("noviuri"),
                                Name = "Ime tacke 2",
                                PositionInTour = 2,
                            },

                        }
                    },
                    400
                },
                new object[]
                {
                    new TouristTourDto
                    {
                        Id=-3,
                        Name = "Neki naziv",
                        AuthorId = -1,
                        Description = "",
                        DistanceInKm = 60,
                        KeyPoints = new List<TourKeyPointDto>()
                        {
                            new TourKeyPointDto
                            {
                                Id = -3340,
                                Latitude = 0,
                                Longitude = 0,
                                Description = "Opis tacke",
                                Image = new Uri("noviuri"),
                                Name = "Ime tacke",
                                PositionInTour = 1,
                            },
                            new TourKeyPointDto
                            {
                                Id = -3341,
                                Latitude = 0,
                                Longitude = 0,
                                Description = "Opis tacke",
                                Image = new Uri("noviuri"),
                                Name = "Ime tacke 2",
                                PositionInTour = 2,
                            },
                            new TourKeyPointDto
                            {
                                Id = -3342,
                                Latitude = 0,
                                Longitude = 0,
                                Description = "Opis tacke3",
                                Image = new Uri("noviuri"),
                                Name = "Ime tacke 3",
                                PositionInTour = 3,
                            },

                        }
                    },
                    200
                }
            };
        }



        private static TouristTourController CreateController(IServiceScope scope)
        {
            return new TouristTourController(scope.ServiceProvider.GetRequiredService<ITouristTourService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }


    }
}
