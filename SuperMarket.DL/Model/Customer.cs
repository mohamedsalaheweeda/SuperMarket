using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuperMarket.DL
{
    public class Customer
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Mid_Name { get; set; }
        public string Last_Name { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Product> product { get; set; } = new List<Product>();
        public ICollection<Order> Order { get; set; } = new List<Order>();
        public ICollection<Payment> Payment { get; set; } = new List<Payment>();
        public ICollection<Review> Review { get; set; } = new List<Review>();

    }

}
