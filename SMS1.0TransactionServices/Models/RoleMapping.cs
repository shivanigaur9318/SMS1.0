using System.ComponentModel.DataAnnotations;

namespace SMS1._0TransactionServices.Models
{
    public class RoleMapping
    {
        [Key]
        public int RoleMappingId { get; set; }
        [Required]
        public int UserId  { get; set;}
        [Required]
        public int RoleId { get; set; }

    }
}
