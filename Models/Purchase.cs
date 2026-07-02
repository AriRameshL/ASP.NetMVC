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
        public int AudioId { get; set; }
        public int CustomerId { get; set; }
        public int Pieces { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string Cancel { get; set; }
        public DateTime CreatedTime {  get; set; }
        public DateTime? CanceledTime { get; set; }

        [ForeignKey(nameof(AudioId))]
        public AudioMaster AudioMaster { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }  =new Customer();

    }
}
