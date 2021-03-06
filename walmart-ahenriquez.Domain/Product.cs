﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace walmart_ahenriquez.Domain
{
    public class Product
    {
        public ObjectId Id { get; set; }

        public int ProductId { get; set; }

        public string Brand { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

        public double GetPriceWithDiscount(double discountRate)
        {
            return Math.Round(Price - (Price * discountRate));
        }
    }
}
