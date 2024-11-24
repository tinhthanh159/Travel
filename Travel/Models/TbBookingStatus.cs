using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class TbBookingStatus
{
    public int BookingStatusId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual TbBooking BookingStatus { get; set; } = null!;
}
