using System;
using System.Collections.Generic;
using System.Text;

namespace walmart_ahenriquez.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string Brand { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }
    }
}
