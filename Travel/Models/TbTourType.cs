using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class TbTourType
{
    public int TypeId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Description { get; set; }

    public string? Icon { get; set; }

    public int? Position { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<TbNews> TbNews { get; set; } = new List<TbNews>();

    public virtual ICollection<TbTour> TbTours { get; set; } = new List<TbTour>();
}
