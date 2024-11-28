using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class TbDestination
{
    public int DestinationId { get; set; }

    public int TourId { get; set; }

    public string? Destination { get; set; }

    public string? Description { get; set; }

    public string? Detail { get; set; }

    public bool? TopDestination { get; set; }

    public string? Image { get; set; }

    public string? NumberTour { get; set; }

    public string? Country { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? IsNew { get; set; }

    public bool IsActive { get; set; }

    public virtual TbTour Tour { get; set; } = null!;
}
