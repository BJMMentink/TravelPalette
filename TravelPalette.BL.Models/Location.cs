using System;
using System.ComponentModel;

namespace TravelPalette.BL.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public string? Description { get; set; }

        [DisplayName("Business Name")]
        public string? BusinessName { get; set; }
        public string? Coordinates { get; set; }

        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }
    }
}