namespace Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int SupCategoryId { get; set; }
        //public int SubCategoryId { get; set; }
        //public Category? SubCategory { get; set; }
        //public ICollection<Category>? SubCategories { get; set; }
        //public ICollection<Product>? Products { get; set; }
       // public ICollection<Size>? Sizes { get; set; }
    }
}