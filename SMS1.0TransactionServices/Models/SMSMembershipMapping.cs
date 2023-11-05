using System.ComponentModel.DataAnnotations;

namespace SMS1._0TransactionServices.Models
{
    public class SMSMembershipMapping:CommonTransaction
    {
        [Key]
        public int MembershipMappingId { get; set; }
        [Required]
        public int MembershipId { get; set;}

        [Required]
        public int UserId { get; set;}
    }
}
