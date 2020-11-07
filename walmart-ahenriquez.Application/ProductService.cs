using System;
using System.Collections.Generic;
using System.Text;
using walmart_ahenriquez.Domain;
using walmart_ahenriquez.Dto;

namespace walmart_ahenriquez.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        private readonly IProductDomainService _productDomainService;

        private readonly ProductFactory _productFactory;

        public ProductService(IProductRepository productRepository,
                        IProductDomainService productDomainService,
                        ProductFactory productFactory)
        {
            _productRepository = productRepository;

            _productDomainService = productDomainService;

            _productFactory = productFactory;
        }

        public IList<ProductDto> Find(SearchDto searchDto)
        {
            int productId;

            SearchTerm searchTerm = new SearchTerm(searchDto.Value);

            IList<ProductDto> result = new List<ProductDto>();

            if (int.TryParse(searchTerm.Value, out productId))
            {
                Product product = _productRepository.FindById(productId);

                searchTerm.Value = productId.ToString();

                if (product != null)
                {
                    CreateProductDtoAndAddItToList(searchTerm, result, product);
                }
            }
            else
            {
                if (searchTerm.Value.Length >= Constants.MinLengthSearchTerm)
                {
                    IList<Product> products = _productRepository.FindByBrandOrDescription(searchTerm.Value);

                    foreach (var product in products)
                    {
                        CreateProductDtoAndAddItToList(searchTerm, result, product);
                    }
                }
            }

            return result;
        }

        private void CreateProductDtoAndAddItToList(SearchTerm searchTerm, IList<ProductDto> result, Product product)
        {
            ProductDto productDto = _productFactory.CreateFromEntity(product, _productDomainService.CalculatePriceWithDiscount(searchTerm, product, Constants.DiscountRate));

            result.Add(productDto);
        }
    }
}