using ASp_MVC.Models;
using ASp_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASp_MVC.Controllers
{
     public class HomeController : Controller
    {
        static int _productId = 1;
        private static readonly List<Product> _products = new();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            
                product.Id = _productId;
                _products.Add(product);
                _productId++;

                ModelState.Clear();


                return View("Index");
           

        }

        public ActionResult ShowProductList()
        {
            ShowProductsViewModel showProductsViewModel = new(_products);
            return View("ShowProductList", showProductsViewModel);
        }

        public ActionResult ShowProductTable()
        {
            ShowProductsViewModel showProductsViewModel = new(_products);
            return View("ShowProductTable",showProductsViewModel);
        }




    }
}