namespace ASp_new.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Password { get; set; }

        public int ProductsQTY { get; set; }

        public User() { }

        public User(int id, string name, int age, string password, int productsQty)
        {
            Id = id;
            Name = name;
            Age = age;
            Password = password;
            ProductsQTY = productsQty;
        }
    }
}