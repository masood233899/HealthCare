using System;
using System.Collections.Generic;

namespace AngularBigBang.Models;

public partial class Booking
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? Date { get; set; }

    public int? UserId { get; set; }

    public int? DoctorId { get; set; }

    public int? TimeId { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual TimeSlot? Time { get; set; }

    public virtual User? User { get; set; }
}
