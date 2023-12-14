using ASp_MVC.Models;
using ASp_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace ASp_MVC.Controllers
{
     public class HomeController : Controller
    {
        static int _productId = 1;
        private static readonly List<Product> _products = new();
        private static Coord _coord = new();

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


        [HttpPost]
        public ActionResult SetLocCoords(string latitude, string longitude)
        {
            if (Double.TryParse(latitude, NumberStyles.Float, CultureInfo.InvariantCulture, out double numLat) && Double.TryParse(longitude, NumberStyles.Float, CultureInfo.InvariantCulture, out double numLon))
            {
                _coord.latitude = numLat;
                _coord.longitude = numLat;
            }
            else
            {
                throw new Exception();
            }
            return RedirectToAction("ShowWeather");
        }

        [HttpGet]
        public ActionResult ShowWeather()
        {
            return View(_coord);
        }
    }
}