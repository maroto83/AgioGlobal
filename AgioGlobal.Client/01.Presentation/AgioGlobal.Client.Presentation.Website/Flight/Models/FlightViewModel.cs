using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using AgioGlobal.Client.Presentation.Website.Airport.Models;

namespace AgioGlobal.Client.Presentation.Website.Flight.Models
{
    public class FlightViewModel
    {
        /// <summary>
        /// Flight name
        /// </summary> 
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The departure airport
        /// </summary>
        [Required]
        public int DepartureAirportId { get; set; }

        /// <summary>
        /// The Destination airport
        /// </summary>
        [Required]
        public int DestinationAirportId { get; set; }
     
        public List<SelectListItem> AirportsList { get; set; }
    }
}