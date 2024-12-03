using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Areas.Admin.Models
{
    [Table("TbAdminUser")]
    public class TbAdminUser
    {
        [Key]
        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public bool? IsAcctive { get; set; }
    }
}