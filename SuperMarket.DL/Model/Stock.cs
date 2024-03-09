namespace SuperMarket.DL
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }

    }

}
