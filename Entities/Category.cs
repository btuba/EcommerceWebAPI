using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Category : IEntity
    {
        [ForeignKey("Category")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SupCategoryId { get; set; }
        public Category? SupCategory { get; set; }
        public ICollection<Product>? Products { get; set; }

    }
}