using System;
using System.Collections.Generic;

namespace TravelPalette.PL;

public partial class tblLocation
{
    public int Id { get; set; }

    public string AddressId { get; set; }

    public string Description { get; set; } = null!;

    public string BusinessName { get; set; } = null!;

    public string Coordinates { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;
}
