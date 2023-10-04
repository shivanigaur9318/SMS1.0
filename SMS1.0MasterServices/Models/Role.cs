using System.ComponentModel.DataAnnotations;

namespace SMS1._0MasterServices.Models
{
    public class Role:CommonMaster
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleType { get; set; }
    }
}
