//Ben Hayden
//October 21

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TripsLog.Models;

namespace TripsLog.Controllers
{
    //home controller
    public class HomeController : Controller
    {
        //database context reference
        private TripContext context { get; set; }

        public HomeController(TripContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            //get database entries and order by destination name
            var trips = context.Trips.OrderBy(m => m.Destination).ToList();
            
            //if there is data in temp data, that means you added trip
            if (TempData.Keys.Contains("destination") && TempData.Peek("destination") != null)
            {
                //set viewdata to show new trip added
                ViewData["SubheaderMsg"] = "Your trip to " + TempData.Peek("destination").ToString() + " has been added";
            }
            TempData.Clear();
            return View(trips);
        }
    }
}
