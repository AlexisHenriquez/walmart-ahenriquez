using System;
using System.Collections.Generic;
using System.Text;

namespace walmart_ahenriquez.Domain
{
    public interface IProductRepository
    {
        Product FindById(int id);

        IList<Product> FindByBrandOrDescription(string brandOrDescription);
    }
}
