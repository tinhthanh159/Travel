using System;
using System.Collections.Generic;

namespace Travel.Models;

public partial class TbBlogComment
{
    public int CommentId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Detail { get; set; }

    public int? BlogId { get; set; }

    public bool IsActive { get; set; }

    public virtual TbBlog? Blog { get; set; }
}
