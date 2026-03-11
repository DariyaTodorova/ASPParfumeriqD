namespace ASPParfumeriq.Models
{
    public class TypeParfume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public DateTime RegisterOn { get; set; }
    }
}
