using ASp_MVC.Models;
using ASp_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Globalization;

namespace ASp_MVC.Controllers
{
     public class HomeController : Controller
    {       
        static int  _consultId = 1;
        private static readonly List<Consult> _consults = new();
        private static readonly List<string> _subjects = new List<string> { "JavaScript", "C#", "Java", "Python", "Основи" };

        public ActionResult Index()
        {
            ViewBag.Subjects = new SelectList(_subjects);
            return View();
        }

        [HttpPost]
        public IActionResult Register(Consult consult)
        {
            if (ModelState.IsValid)
            {
                if (consult.Subject == "Основи" && consult.Date.DayOfWeek == DayOfWeek.Monday)
                {
                    ModelState.AddModelError("DateOfConsultation", "Консультація щодо 'Основи' не може проходити по понеділках.");
                    ViewBag.Subjects = new SelectList(_subjects);
                    return View("Index", consult);
                }

                consult.Id = _consultId;
                _consults.Add(consult);
                _consultId++;

                ModelState.Clear();

                return RedirectToAction("Index");
            }
            else
            {
                foreach (var key in ModelState.Keys)
                {
                    for (int i = 0; i < ModelState[key].Errors.Count; i++)
                    {
                        var error = ModelState[key].Errors[i];
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }

                ViewBag.Subjects = new SelectList(_subjects);
                return View("Index", consult);
            }
        }

        public IActionResult ShowConsults()
        {
            ShowConsultsViewModel showConsultsViewModel = new(_consults);
            return View(showConsultsViewModel);
        }

    }
}