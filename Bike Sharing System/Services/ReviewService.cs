using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bike_Sharing_System.Models;

namespace Bike_Sharing_System.Services
{
    public class ReviewService
    {
        private readonly IMongoCollection<Review> _reviews;

        public ReviewService(MongoDBContext context)
        {
            _reviews = context.GetCollection<Review>("Reviews");
        }

        public void SubmitReview(Review review)
        {
            _reviews.InsertOne(review);
        }

        public List<Review> GetReviews(string bikeId)
        {
            return _reviews.Find(r => r.BikeId == bikeId).ToList();
        }
    }
}