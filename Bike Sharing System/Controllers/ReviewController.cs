using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Bike_Sharing_System.Services;
using Bike_Sharing_System.Models;
using Microsoft.AspNetCore.Http;

namespace Bike_Sharing_System.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public IActionResult SubmitReview(string bikeId, string comment, int rating)
        {
            var review = new Review
            {
                MemberId = HttpContext.Session.GetString("UserId"),
                BikeId = bikeId,
                Comment = comment,
                Rating = rating
            };

            _reviewService.SubmitReview(review);
            return RedirectToAction("ViewReviews", new { bikeId });
        }

        public IActionResult ViewReviews(string bikeId)
        {
            var reviews = _reviewService.GetReviews(bikeId);
            return View(reviews);
        }
    }
}