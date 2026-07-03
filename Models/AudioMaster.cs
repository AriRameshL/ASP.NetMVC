using System.ComponentModel.DataAnnotations;

namespace AudioSeller.Models
{
    public class AudioMaster
    {
        [Key]
        public int AudioId { get; set; }
        [Required(ErrorMessage ="Enter Audio Name")]
        [StringLength(50)]
        public string AudioName {  get; set; }
        [StringLength(50)]
        public string AuthorName {  get; set; }
        [StringLength(50)]
        public string MovieName { get; set; }
        public string CoverImage { get; set; }

        [Required]
        [Range(typeof(double),"0.01","100000.00",ErrorMessage ="Rate Must be between 0.01 to 100000.00")]
        public double Rate { get; set; } = 0;

    }
}
