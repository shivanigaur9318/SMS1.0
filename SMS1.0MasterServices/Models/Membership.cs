using System.ComponentModel.DataAnnotations;

namespace SMS1._0MasterServices.Models
{
    public class Membership:CommonMaster
    {
        [Key]
        public int MembershipId { get; set; }
        [Required]
        public string MembershipName { get; set; }

    }
}
