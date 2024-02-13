using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPalette.BL.Models
{
    public class LocationTag
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int TagId { get; set; }
    }
}
