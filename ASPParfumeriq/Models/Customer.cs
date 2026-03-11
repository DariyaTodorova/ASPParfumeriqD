using Microsoft.AspNetCore.Identity;

namespace ASPParfumeriq.Models
{
    public class Customer:IdentityUser
    {
       
        public string FirstName { get; set; }           
        public string LastName { get; set; }
        public string Address { get; set; } 
        public ICollection<Order> Orders { get; set; }
        public DateTime RegisterOn { get; set; }
    }
}
