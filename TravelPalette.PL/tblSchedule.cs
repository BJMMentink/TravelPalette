using System;
using System.Collections.Generic;

namespace TravelPalette.PL;

public partial class tblSchedule
{
    public int Id { get; set; }

    public int LocationId { get; set; }

    public TimeOnly? MondayOpen { get; set; }

    public TimeOnly? MondayClose { get; set; }

    public TimeOnly? TuesdayOpen { get; set; }

    public TimeOnly? TuesdayClose { get; set; }

    public TimeOnly? WednesdayOpen { get; set; }

    public TimeOnly? WednesdayClose { get; set; }

    public TimeOnly? ThursdayOpen { get; set; }

    public TimeOnly? ThursdayClose { get; set; }

    public TimeOnly? FridayOpen { get; set; }

    public TimeOnly? FridayClose { get; set; }

    public TimeOnly? SaturdayOpen { get; set; }

    public TimeOnly? SaturdayClose { get; set; }

    public TimeOnly? SundayOpen { get; set; }

    public TimeOnly? SundayClose { get; set; }
}
