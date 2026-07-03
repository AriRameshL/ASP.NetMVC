using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AudioSeller.Models
{
    [Index(nameof(MobileNo), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(OperName), IsUnique = true)]
    public class Operator
    {
        [Key]
        public int OperCode { get; set; }
        [Required(ErrorMessage = "Enter The Operator Name")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Enter The Valid Operator Name")]
        public string OperName { get; set; }
        [Required(ErrorMessage = "Enter The Password")]
        [StringLength(maximumLength: 15, ErrorMessage = "Enter Valid Password", MinimumLength = 4)]
        [RegularExpression("^[a-zA-Z0-9]+$",ErrorMessage ="Only Numbers And Alphapets Are Allowed")]
        public string Password { get; set; }
        public DateOnly DOB { get; set; }
        [Required(ErrorMessage = "Enter The Mobile No")]
        [StringLength(10, ErrorMessage = "Enter Valid MobileNo", MinimumLength = 10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers Are Allowed")]
        public string MobileNo { get; set; }
        [EmailAddress(ErrorMessage = "Enter The Valid Email Address")]
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(maximumLength: 1,MinimumLength =1)]
        public  string Gender { get; set; }
        [StringLength(1,ErrorMessage ="Select Active Type")]
        public string Active { get; set; } = string.Empty;
        
    }
}
