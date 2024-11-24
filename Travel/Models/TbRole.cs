using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class TbRole
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TbAccount> TbAccounts { get; set; } = new List<TbAccount>();
}
