using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class TbAdminUser
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? IsAcctive { get; set; }
}
