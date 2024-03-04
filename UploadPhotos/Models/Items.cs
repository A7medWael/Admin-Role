using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UploadPhotos.Models
{
    public class Items
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string imagePath { get; set; }
        [NotMapped]
        public IFormFile ClientFile { get; set; }
    }
}
