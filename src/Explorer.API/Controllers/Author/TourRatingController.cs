using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Rating;
using Explorer.Tours.API.Dtos.Statistics;
using Explorer.Tours.API.Public.Rating;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.Core.UseCases.Rating;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/tourrating")]
    public class TourRatingController: BaseApiController
    {
        private readonly ITourRatingService _ratingService;
        private readonly ITourService _tourService;

        public TourRatingController(ITourRatingService ratingService, ITourService tourService)
        {
            _ratingService = ratingService;
            _tourService = tourService;
        }

        [HttpGet]
        public ActionResult<PagedResult<TourRatingDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _ratingService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("tour/{tourId:int}")]
        public ActionResult<List<TourRatingDto>> GetByTourId(int tourId)
        {
            var result = _ratingService.GetByTourId(tourId);
            return CreateResponse(result);
        }

        [HttpGet("average/{authorId:int}")]
        public ActionResult<double> GetAverageAuthorRating(int authorId)
        {
            var tours = _tourService.GetAllByAuthorId(authorId);

            if (tours == null || !tours.Any())
            {
                return NotFound();
            }

            var result = _ratingService.GetAverageAuthorRating(tours);
            return CreateResponse(result);
        }

        [HttpGet("getBestRatedStats")]
        public ActionResult<List<TourStatisticsDto>> GetBestRatedStatistics()
        {
            var result = _ratingService.GetBestRatedStatistics();
            return CreateResponse(result);
        }
    }
}
