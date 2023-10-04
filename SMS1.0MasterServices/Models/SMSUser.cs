using System.ComponentModel.DataAnnotations;

namespace SMS1._0MasterServices.Models
{
    public class SMSUser:CommonMaster
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int PhoneNo {  get; set; }
        public string Address { get; set; }



    }
}
