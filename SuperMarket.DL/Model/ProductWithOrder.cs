namespace SuperMarket.DL
{
    public class ProductWithOrder
    {
        public int Id { get; set; }
        public double Discount_AllTotal { get; set; }
        public double Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

}
