using Bike_Sharing_System.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bike_Sharing_System.Services
{
    public class BookingService
    {
        private readonly IMongoCollection<Booking> _bookings;
        private readonly IMongoCollection<Bike> _bikes;

        public BookingService(MongoDBContext context)
        {
            _bookings = context.GetCollection<Booking>("Bookings");
            _bikes = context.GetCollection<Bike>("Bikes");
        }

        public void BookBike(string memberId, string bikeId, DateTime returnDate)
        {
            var bike = _bikes.Find(b => b.Id == bikeId).FirstOrDefault();
            if (bike != null && bike.IsAvailable)
            {
                bike.IsAvailable = false;
                bike.BookedBy = memberId;

                var booking = new Booking
                {
                    MemberId = memberId,
                    BikeId = bikeId,
                    BookingDate = DateTime.UtcNow,
                    ReturnDate = returnDate
                };

                _bookings.InsertOne(booking);
                _bikes.ReplaceOne(b => b.Id == bikeId, bike);
            }
        }

        public List<Booking> GetBookingsByMember(string memberId)
        {
            return _bookings.Find(b => b.MemberId == memberId).ToList();
        }
    }
}