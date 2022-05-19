namespace Entities
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Detail { get; set; }
        public Customer Customer { get; set; }
    }
}