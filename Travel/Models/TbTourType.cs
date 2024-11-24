using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class TbTourType
{
    public int TypeId { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<TbNews> TbNews { get; set; } = new List<TbNews>();

    public virtual ICollection<TbTour> TbTours { get; set; } = new List<TbTour>();
}
