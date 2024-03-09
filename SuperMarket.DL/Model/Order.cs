namespace SuperMarket.DL
{
    public class Order
    {
        public int Id { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public double List_Price { get; set; }
        public int CustomerId { get; set; }
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
        public ICollection<Product> Product { get; set; } = new List<Product>();
        public ICollection<ProductWithOrder> ProductWithOrder { get; set; } = new List<ProductWithOrder>();
    }

}
