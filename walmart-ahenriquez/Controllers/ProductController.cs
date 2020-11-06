using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace walmart_ahenriquez.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Search()
        {
            return View();
        }

        public IActionResult SearchResults()
        {
            return PartialView("Product/_SearchResults");
        }
    }
}
