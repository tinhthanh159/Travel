using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class TbTourDetail
{
    public int TourDetailId { get; set; }

    public int TourId { get; set; }

    public DateTime? DepartureDate { get; set; }

    public int? QuantityPeople { get; set; }

    public string? HotelLevel { get; set; }

    public string? Request { get; set; }

    public virtual TbTour Tour { get; set; } = null!;
}
