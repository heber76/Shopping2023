using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Shopping2023.Data.Entities
{
    public class ProductImage
    {

        public int Id { get; set; }

        public Product Product { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        //TODO: Pending to change to the correct path
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:7084/imagenes/noimage.png"
            : $"https://shopping2023.blob.core.windows.net/products/{ImageId}";

    }
}
