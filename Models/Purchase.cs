using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AudioSeller.Models
{
    public class Purchase
    {
        [Key]
        public int TranNo { get; set; }
        [Required]
        public DateTime TranDate { get; set; }
        [Required(ErrorMessage ="Select Valid Audio")]
        public int AudioId { get; set; }
        public int CustomerId { get; set; }
        [Range(1,1000,ErrorMessage ="Enter The Valid Pieces")]
        public int Pieces { get; set; }
        [Required]
        public double Rate { get; set; }
        public double Amount { get; set; }
        [StringLength(1)]
        public string Cancel { get; set; }
        public DateTime CreatedTime {  get; set; }
        public DateTime? CanceledTime { get; set; }

        [ForeignKey(nameof(AudioId))]
        public AudioMaster AudioMaster { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }  =new Customer();

    }
}
