using System.ComponentModel.DataAnnotations;

namespace MyFirstPro.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Status
        {
            get
            {
                return Quantity > 0 ? "In Stock" : "Out of Stock";
            }
        }
    }
}

