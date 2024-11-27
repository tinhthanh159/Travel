using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class TbTourGuide
{
    public int GuideId { get; set; }

    public string FullName { get; set; } = null!;

    public bool Gender { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? LanguageSkills { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public string? Image { get; set; }
}
