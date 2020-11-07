using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using walmart_ahenriquez.Dto;

namespace walmart_ahenriquez.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(SearchDto searchDto)
        {
            if (ModelState.IsValid)
            {

            }

            return View(searchDto);
        }
    }
}
