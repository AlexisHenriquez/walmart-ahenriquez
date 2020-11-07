using System;
using System.Collections.Generic;
using System.Text;
using walmart_ahenriquez.Dto;

namespace walmart_ahenriquez.Application
{
    public class ProductDtoBuilder
    {
        private int _productId;

        private string _brand;

        private string _description;

        private string _image;

        private double _originalPrice;

        private double _priceWithDiscount;

        public ProductDtoBuilder WithProductId(int productId)
        {
            _productId = productId;

            return this;
        }

        public ProductDtoBuilder WithBrand(string brand)
        {
            _brand = brand;

            return this;
        }

        public ProductDtoBuilder WithDescription(string description)
        {
            _description = description;

            return this;
        }

        public ProductDtoBuilder WithImage(string image)
        {
            _image = image;

            return this;
        }

        public ProductDtoBuilder WithOriginalPrice(double originalPrice)
        {
            _originalPrice = originalPrice;

            return this;
        }

        public ProductDtoBuilder WithPriceWithDiscount(double priceWithDiscount)
        {
            _priceWithDiscount = priceWithDiscount;

            return this;
        }

        public ProductDto Build()
        {
            return new ProductDto()
            {
                Brand = _brand,
                Description = _description,
                Image = _image,
                OriginalPrice = _originalPrice,
                PriceWithDiscount = _priceWithDiscount,
                ProductId = _productId
            };
        }
    }
}
