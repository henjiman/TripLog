//Ben Hayden
//October 21

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

//Trip model
namespace TripsLog.Models
{
    public class Trip
    {
        //Auto generated primary key
        public int? TripId { get; set; }

        //Attributes of each trip model
        [Required(ErrorMessage = "Please enter a destination.")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "Please enter a start date.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please enter an end date.")]
        public DateTime? EndDate { get; set; }
        public string Accommodation { get; set; }
        public string AccommodationPhone { get; set; }
        public string AccommodationEmail { get; set; }
        public string ThingToDo1 { get; set; }
        public string ThingToDo2 { get; set; }
        public string ThingToDo3 { get; set; }
    }
}
