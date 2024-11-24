using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class TbAccount
{
    public int AccountId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? RoleId { get; set; }

    public string? LastLogin { get; set; }

    public bool IsActive { get; set; }

    public virtual TbRole? Role { get; set; }

    public virtual ICollection<TbTour> TbTours { get; set; } = new List<TbTour>();
}
