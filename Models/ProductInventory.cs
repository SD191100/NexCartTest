using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NexCart.Models
{
    public class ProductInventory
    {
        [Key]
        public int InventoryId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int StockAvailable { get; set; }

        [Required]
        public int StockReserved { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
