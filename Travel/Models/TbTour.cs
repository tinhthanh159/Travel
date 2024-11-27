using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class TbTour
{
    public int TourId { get; set; }

    public int TypeId { get; set; }

    public string? TourName { get; set; }

    public string? Introduce { get; set; }

    public int? Price { get; set; }

    public string? PriceSale { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Destination { get; set; }

    public bool? TopDestination { get; set; }

    public int? AccountId { get; set; }

    public bool? IsBestTour { get; set; }

    public bool? IsNew { get; set; }

    public string? Country { get; set; }

    public string? TourDuration { get; set; }

    public int? Assess { get; set; }

    public bool IsActive { get; set; }

    public int? Star { get; set; }

    public virtual TbAccount? Account { get; set; }

    public virtual ICollection<TbTourComment> TbTourComments { get; set; } = new List<TbTourComment>();

    public virtual ICollection<TbTourDetail> TbTourDetails { get; set; } = new List<TbTourDetail>();

    public virtual TbTourType Type { get; set; } = null!;
}
