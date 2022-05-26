using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Size>? Sizes { get; set; } = new List<Size>();
        public ICollection<Image> Images { get; set; }
        public string? Url { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Color> Colors { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; } = false;

        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }
        public Inventory? Inventory { get; set; }
    }
}