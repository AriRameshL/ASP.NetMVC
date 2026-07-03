using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AudioSeller.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Enter The Customer Name")]
        [StringLength(100)]
        public string CustName { get; set; }= string.Empty;
        [StringLength(250)]
        public string CustAddress { get; set; } = string.Empty;
        [Required(ErrorMessage ="Select Gender")]
        [StringLength(1)]
        public string Gender {  get; set; } = string.Empty;
        [EmailAddress(ErrorMessage ="Enter Valid Email Address")]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage ="Enter The Mobile No")]
        [StringLength(10,ErrorMessage ="Enter Valid MobileNo",MinimumLength =10)]
        public string MobileNo { get; set;} = string.Empty;
        [StringLength(100)]
        public string City { get; set; } = string.Empty;
        [StringLength(100)]
        public string District { get; set; } = string.Empty;
        [StringLength(6, ErrorMessage = "Enter Valid Pincode", MinimumLength = 6)]
        public string PinCode { get; set; }
    }
}
