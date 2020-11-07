using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using walmart_ahenriquez.Application;
using walmart_ahenriquez.Dto;

namespace walmart_ahenriquez.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Search()
        {
            return View(new SearchDto());
        }

        [HttpPost]
        public IActionResult Search(SearchDto searchDto)
        {
            if (ModelState.IsValid)
            {
                searchDto.Products = _productService.Find(searchDto);
            }

            return View(searchDto);
        }
    }
}