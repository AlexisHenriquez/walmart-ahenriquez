using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace walmart_ahenriquez.Domain
{
    public class Product
    {
        public string _Id { get; set; }

        public string Id { get; set; }

        public string Brand { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int Price { get; set; }

        public int GetPriceWithDiscount(double discountRate)
        {
            return new int();
        }
    }
}
