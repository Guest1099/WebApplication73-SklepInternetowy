﻿using Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class NewsletterController : Controller
    {
        private ApplicationDbContext _context;

        public NewsletterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
            => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string email)
        {

            return View();
        }

        [HttpGet]
        public IActionResult Delete(string email)
        {
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(string email)
        {
            return View();
        }



    }
}
