using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace SuperMarket.DL
{
    public class User : IdentityUser<int>
    {

        
        public string Name { get; set; }
        public string Password { get; set; }

        public ICollection<Categorey> Categories { get; set; } = new List<Categorey>();
        public ICollection<Brand> Brand { get; set; } = new List<Brand>();
        public ICollection<Order> Order { get; set; } = new List<Order>();
        public ICollection<Product> Product { get; set; } = new List<Product>();
        public ICollection<Customer> Customer { get; set; } = new List<Customer>();
        public ICollection<Review> Review { get; set; } = new List<Review>();
        public ICollection<Payment> Payment { get; set; } = new List<Payment>();
        public ICollection<ProductWithOrder> ProductWithOrder { get; set; } = new List<ProductWithOrder>();
        public ICollection<Stock> Stock { get; set; } = new List<Stock>();



    }

}
