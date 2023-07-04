using System;
using System.Collections.Generic;

namespace AngularBigBang.Models;

public partial class TimeSlot
{
    public int Id { get; set; }

    public string AddTimeSlot { get; set; } = null!;

    public TimeSpan? StartTime { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
