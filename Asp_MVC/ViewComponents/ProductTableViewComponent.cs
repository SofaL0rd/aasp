using ASp_MVC.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Collections.Generic;
using System.Text;

namespace ASp_MVC.ViewComponents
{
    public class ProductTableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<Product> products)
        {
            return View(products);
        }
    }
}