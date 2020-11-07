using System;
using System.Collections.Generic;
using System.Text;

namespace walmart_ahenriquez.Domain
{
    public interface IProductDomainService
    {
        public double CalculatePriceWithDiscount(SearchTerm searchTerm, Product product, double discountRate);
    }
}