using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace ASp_MVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public Product()
        {
            CreatedDate = DateTime.Now;
        }
    }
}