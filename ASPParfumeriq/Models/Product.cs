namespace ASPParfumeriq.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public int TypeParfumeId { get; set; }
        public TypeParfume TypeParfume { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }
        public string Description { get; set; }
        public DateTime RegisterOn { get; set; }
    }
}
