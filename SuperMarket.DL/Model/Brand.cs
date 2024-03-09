namespace SuperMarket.DL
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Product> product { get; set; } = new List<Product>();
        public ICollection<Categorey> Categorey { get; set; } = new List<Categorey>();

    }

}
