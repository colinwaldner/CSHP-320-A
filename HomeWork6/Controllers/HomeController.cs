using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork6.Models;

namespace HomeWork6.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new BirthdayCard());
        }
        [HttpPost]
        public IActionResult Index(BirthdayCard birthdayCard)
        {
            if (ModelState.IsValid)
            {
                return View("CardSent", birthdayCard);

            }
            else
            {
                return View(birthdayCard);
            }
        }
    }
}
