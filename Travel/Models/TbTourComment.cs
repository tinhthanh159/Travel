using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class TbTourComment
{
    public int CommentId { get; set; }

    public int TourId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Image { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Title { get; set; }

    public string? Detail { get; set; }

    public bool IsActive { get; set; }

    public int? Star { get; set; }

    public virtual TbTour Tour { get; set; } = null!;
}
