using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class TbBooking
{
    public int BookingId { get; set; }

    public string? CustomerName { get; set; }

    public int? Phone { get; set; }

    public string? Address { get; set; }

    public int? TotalAmount { get; set; }

    public int? Quanlity { get; set; }

    public int? BookingStatusId { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<TbBookingDetail> TbBookingDetails { get; set; } = new List<TbBookingDetail>();

    public virtual TbBookingStatus? TbBookingStatus { get; set; }
}
