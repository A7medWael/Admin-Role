using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UploadPhotos.Models
{
    public class Info
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;
        public byte[]? dbimage { get; set; }
        [NotMapped]
        public IFormFile ClientFile { get; set; }

        [NotMapped]
        public string GetSrc 
        { get
             {
                if (dbimage != null)
                {
                    string base64string=Convert.ToBase64String(dbimage,0,dbimage.Length);
                    return "data:image/jpg;base64,"+ base64string;
                }
                else
                {
                    return string.Empty;
                }
             }  
        }
    }
}
