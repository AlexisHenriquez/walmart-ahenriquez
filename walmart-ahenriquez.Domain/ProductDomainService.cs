using System;
using System.Collections.Generic;
using System.Text;

namespace walmart_ahenriquez.Domain
{
    public class ProductDomainService : IProductDomainService
    {
        public double CalculatePriceWithDiscount(SearchTerm searchTerm, Product product, double discountRate)
        {
            return (!searchTerm.IsPalindrome) ? product.Price : product.GetPriceWithDiscount(discountRate);
        }
    }
}