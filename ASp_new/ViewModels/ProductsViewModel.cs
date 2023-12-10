using ASp_new.Models;

namespace ASp_new.ViewModels
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public int Id { get; set; }

        public ProductsViewModel() { }
        public ProductsViewModel(IEnumerable<Product> products)
        {
            Products = products;
        }

       
    }
}