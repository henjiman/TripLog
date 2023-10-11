//Ben Hayden
//October 21

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripsLog.Models;

namespace TripsLog.Controllers
{
    public class TripController : Controller
    {
        private TripContext context { get; set; }

        public TripController(TripContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult AddStep1()
        {
            ViewData["SubheaderMsg"] = "Add Trip Destination";
            return View();
        }

        [HttpPost]
        public IActionResult AddStep1(Trip trip)
        {
            if (ModelState.IsValid)
            {
                TempData["destination"] = trip.Destination;
                TempData["startDate"] = trip.StartDate.ToString("MM/dd/yyyy");
                TempData["endDate"] = trip.EndDate.ToString("MM/dd/yyyy");
                if (trip.Accommodation != null)
                {
                    TempData["accommodation"] = trip.Accommodation;
                    return RedirectToAction("AddStep2");
                }
                return RedirectToAction("AddStep3");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult AddStep2()
        {
            ViewData["SubheaderMsg"] = "Add Info for " + TempData.Peek("accommodation").ToString();
            return View();
        }
        [HttpPost]
        public IActionResult AddStep2(Trip trip)
        {
            if (trip.AccommodationPhone != null) TempData["accommodationPhone"] = trip.AccommodationPhone;
            if (trip.AccommodationEmail != null) TempData["accommodationEmail"] = trip.AccommodationEmail;
            return RedirectToAction("AddStep3");
        }
        [HttpGet]
        public IActionResult AddStep3()
        {
            ViewData["SubheaderMsg"] = "Add Things to Do in " + TempData.Peek("destination").ToString();
            return View();
        }
        [HttpPost]
        public IActionResult AddStep3(Trip trip)
        {
            if (trip.ThingToDo1 != null) TempData["thing1"] = trip.ThingToDo1;
            if (trip.ThingToDo2 != null) TempData["thing2"] = trip.ThingToDo2;
            if (trip.ThingToDo3 != null) TempData["thing3"] = trip.ThingToDo3;

            Trip newTrip = new Trip();

            newTrip.Destination = TempData["destination"].ToString();
            if (TempData.ContainsKey("accommodation")) newTrip.Accommodation = TempData["accommodation"].ToString();
            if (TempData.ContainsKey("startDate")) newTrip.StartDate = Convert.ToDateTime(TempData["startDate"].ToString());
            if (TempData.ContainsKey("endDate")) newTrip.EndDate = Convert.ToDateTime(TempData["endDate"].ToString());
            if (TempData.ContainsKey("accommodationEmail")) newTrip.AccommodationEmail = TempData["accommodationEmail"].ToString();
            if (TempData.ContainsKey("accommodationPhone")) newTrip.AccommodationPhone = TempData["accommodationPhone"].ToString();
            if (TempData.Keys.Contains("thing1")) newTrip.ThingToDo1 = TempData["thing1"].ToString();
            if (TempData.Keys.Contains("thing2")) newTrip.ThingToDo2 = TempData["thing2"].ToString();
            if (TempData.Keys.Contains("thing3")) newTrip.ThingToDo3 = TempData["thing3"].ToString();

            context.Trips.Add(newTrip);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var trip = context.Trips.Find(id);
            context.Remove(trip);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}