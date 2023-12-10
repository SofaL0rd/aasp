﻿using ASp_new.Models;
using ASp_new.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASp_new.Controllers
{
    public class HomeController : Controller
    {
        static int _userId = 1;
        static int _productId = 1;
        static readonly List<User> _users = new List<User>();
        static readonly List<Product> _products = new List<Product>();

        public IActionResult Index()
        {
            IndexViewModel users = new IndexViewModel(_users);
            return View(users);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult AddUser(User user)
        {
            if ( user.Age > 16)
            {
                user.Id = _userId;
                _users.Add(user);
                for (int i = 0; i < user.ProductsQTY; i++)
                {
                    _products.Add(new Product(_productId, user));
                    Console.WriteLine(_products[i].Id);
                    _productId++;
                }
                _userId++;
                return View("Index", new IndexViewModel(_users));
            }
            return View("RegisterError");
        }


        public IActionResult ShowProducts(User user)
        {
            ProductsViewModel products = new ProductsViewModel(
                _products.Where(p => p.UserOwn.Id == user.Id).ToList()
                );
            return View(products);
        }

        [HttpPost]
        public IActionResult ChangeProducts(IFormCollection form)
        {
            string newId = form["Id"];
            string newName = form["Name"];
            string newDescription = form["Description"];

            var newProduct = _products.FirstOrDefault(p => p.Id == int.Parse(newId));
            newProduct.Name = newName;
            newProduct.Description = newDescription;

            return View("Index", new IndexViewModel(_users));
        }


       
    }
}