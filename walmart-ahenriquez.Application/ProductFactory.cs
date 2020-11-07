using System;
using System.Collections.Generic;
using System.Text;
using walmart_ahenriquez.Domain;
using walmart_ahenriquez.Dto;

namespace walmart_ahenriquez.Application
{
    public class ProductFactory
    {
        public ProductDto CreateFromEntity(Product product, double priceWithDiscount)
        {
            return new ProductDtoBuilder()
                .WithBrand(product.Brand)
                .WithDescription(product.Description)
                .WithImage(product.Image)
                .WithOriginalPrice(product.Price)
                .WithPriceWithDiscount(priceWithDiscount)
                .WithProductId(product.ProductId)
                .Build();
        }
    }
}