using System;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Bike_Sharing_System.Services;
using Microsoft.AspNetCore.Http;

namespace Bike_Sharing_System.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IActionResult Book(string bikeId)
        {
            if (HttpContext.Session.GetString("UserId") == null)
                return RedirectToAction("SignIn", "Member");

            return View(new { BikeId = bikeId });
        }

        [HttpPost]
        public IActionResult ConfirmBooking(string bikeId, DateTime returnDate)
        {
            string userId = HttpContext.Session.GetString("UserId");
            _bookingService.BookBike(userId, bikeId, returnDate);
            return RedirectToAction("MyBookings");
        }

        public IActionResult MyBookings()
        {
            string userId = HttpContext.Session.GetString("UserId");
            var bookings = _bookingService.GetBookingsByMember(userId);
            return View(bookings);
        }
    }
}