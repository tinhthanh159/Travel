using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class TbBookingDetail
{
    public int BookingDetailId { get; set; }

    public int BookingId { get; set; }

    public int TourId { get; set; }

    public int? Price { get; set; }

    public int? Quantity { get; set; }

    public virtual TbBooking Booking { get; set; } = null!;
}
