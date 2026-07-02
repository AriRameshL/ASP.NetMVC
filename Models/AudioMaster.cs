using System.ComponentModel.DataAnnotations;

namespace AudioSeller.Models
{
    public class AudioMaster
    {
        [Key]
        public int AudioId { get; set; }
        [Required]
        public string AudioName {  get; set; }
        public string AuthorName {  get; set; }
        public string MovieName { get; set; }
        public string CoverImage { get; set; }

        [Required]
        public double Rate { get; set; } = 0;

    }
}
