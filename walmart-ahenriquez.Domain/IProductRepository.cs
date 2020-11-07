using System;
using System.Collections.Generic;
using System.Text;

namespace walmart_ahenriquez.Domain
{
    public interface IProductRepository
    {
        Product FindById(int productId);

        IList<Product> FindByBrandOrDescription(string brandOrDescription);
    }
}
