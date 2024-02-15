using System;
using System.Collections.Generic;

namespace TravelPalette.PL;

public partial class tblAddress
{
    public int Id { get; set; }

    public string StreetName { get; set; } = null!;

    public string City { get; set; } = null!;

    public string ZIP { get; set; } = null!;

    public string State { get; set; } = null!;
}
