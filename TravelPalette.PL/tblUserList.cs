using System;
using System.Collections.Generic;

namespace TravelPalette.PL;

public partial class tblUserList
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ListId { get; set; }

    public string ListName { get; set; } = null!;
}
