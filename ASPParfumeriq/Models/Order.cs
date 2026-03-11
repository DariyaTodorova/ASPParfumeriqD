namespace ASPParfumeriq.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Products { get; set; }
        public string CustomerId { get; set; }
        public Customer Customers { get; set; }
        public int OrderQuantity { get; set; }
        
        public DateTime RegisterOn { get; set; }
    }
}