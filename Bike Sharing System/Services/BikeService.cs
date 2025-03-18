using Bike_Sharing_System.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Bike_Sharing_System.Services
{
    public class BikeService
    {
        private readonly IMongoCollection<Bike> _bikes;

        public BikeService(MongoDBContext context)
        {
            _bikes = context.GetCollection<Bike>("Bikes");
        }

        public List<Bike> SearchBikes(string location, string bikeType)
        {
            return _bikes.Find(bike => bike.Location == location && bike.BikeType == bikeType && bike.IsAvailable).ToList();
        }
    }
}