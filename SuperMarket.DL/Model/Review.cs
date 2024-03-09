namespace SuperMarket.DL
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

}
