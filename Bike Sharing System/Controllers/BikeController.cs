using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Web;
using Bike_Sharing_System.Services;

namespace Bike_Sharing_System.Controllers
{
    public class BikeController : Controller
    {
        private readonly BikeService _bikeService;

        public BikeController(BikeService bikeService)
        {
            _bikeService = bikeService;
        }

        public IActionResult Search() => (IActionResult)View();

        [HttpPost]
        public IActionResult Search(string location, string bikeType)
        {
            var bikes = _bikeService.SearchBikes(location, bikeType);
            return View("SearchResults", bikes);
        }
    }
}