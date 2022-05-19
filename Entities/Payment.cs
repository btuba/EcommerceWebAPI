namespace Entities
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Customer Customer { get; set; }
        public string Data { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}