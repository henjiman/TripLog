//Ben Hayden
//October 21

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TripsLog.Models
{
    //Trip context class
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options) { }
        public DbSet<Trip> Trips { get; set; }

        //starter data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    TripId = 1,
                    Destination = "New York",
                    StartDate = new DateTime(2020, 11, 19),
                    EndDate = new DateTime(2020, 11, 21),
                    Accommodation = "The Ritz",
                    ThingToDo1 = "Ride the Subway",
                    ThingToDo2 = "Ferry Ride"
                }
            );
        }
    }
}
