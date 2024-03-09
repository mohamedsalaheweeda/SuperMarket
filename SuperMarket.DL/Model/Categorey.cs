namespace SuperMarket.DL
{
    public class Categorey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public int BrandId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public Brand Brand { get; set; }
        public ICollection<Product> product { get; set; } = new List<Product>();


    }

}
