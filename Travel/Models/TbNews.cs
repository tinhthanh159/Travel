using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class TbNews
{
    public int NewsId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public int? TypeId { get; set; }

    public string? Description { get; set; }

    public string? Detail { get; set; }

    public string? Image { get; set; }

    public string? SeoTitle { get; set; }

    public string? SeoDescription { get; set; }

    public string? SeoKeywords { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public virtual TbTourType? Type { get; set; }
}
