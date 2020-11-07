using System;
using System.Collections.Generic;
using walmart_ahenriquez.Dto;

namespace walmart_ahenriquez.Application
{
    public interface IProductService
    {
        IList<ProductDto> Find(SearchDto searchDto);
    }
}