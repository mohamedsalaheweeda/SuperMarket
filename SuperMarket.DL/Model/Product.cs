namespace SuperMarket.DL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model_Year { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double Quantity { get; set; }
        public int BrandId { get; set; }
        public int Categoreyid { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Brand Brand { get; set; }
        public Categorey Categorey { get; set; }
        public ICollection<Stock> Stock { get; set; } = new List<Stock>();
        public ICollection<Customer> Customer { get; set; } = new List<Customer>();
        public ICollection<Order> Order { get; set; } = new List<Order>();
        public ICollection<ProductWithOrder> ProductWithOrder { get; set; } = new List<ProductWithOrder>();

    }

}
