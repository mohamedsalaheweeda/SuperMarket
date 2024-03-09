namespace SuperMarket.DL
{
    public class Payment
    {
        public int Id { get; set; }
        public double Type_Amount { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Order> Order { get; set; } = new List<Order>();

    }

}
