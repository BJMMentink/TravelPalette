namespace TravelPalette.BL.Models
{
    public class Location
    {
        public int Id { get; set; }

        public int AddressId { get; set; }

        public string Description { get; set; }

        public string BusinessName { get; set; }

        public string Coordinates { get; set; }

        public string PhoneNumber { get; set; }
    }
}
