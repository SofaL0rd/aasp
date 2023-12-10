namespace ASp_new.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User UserOwn { get; set; }
        public string Description { get; set; }

        public Product(int id,  User userOwn, string name = "Product", string description="Desc")
        {
            Id = id;
            Name = name;
            UserOwn = userOwn;
            Description = description;
        }
    }
}
