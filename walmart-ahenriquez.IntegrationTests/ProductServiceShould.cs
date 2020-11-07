using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using walmart_ahenriquez.Application;
using walmart_ahenriquez.Domain;
using walmart_ahenriquez.Dto;
using walmart_ahenriquez.Infrastructure;
using Xunit;

namespace walmart_ahenriquez.IntegrationTests
{
    public class ProductServiceShould : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;

        public ProductServiceShould(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData(5, "peuoooypt")]
        [InlineData(8, "sfzkvoñ")]
        [InlineData(11, "iñmfdpd")]
        [InlineData(14, "dcc gdodkñg")]
        [InlineData(17, "cni tñcapdx")]
        public void GetProductById(int productId, string expected)
        {
            SearchDto searchDto = new SearchDto() { Value = productId.ToString() };

            IProductService sut = new ProductService(new ProductRepository(_fixture.DbContext), 
                new ProductDomainService(), 
                new ProductFactory());

            searchDto.Products = sut.Find(searchDto);

            Assert.Equal(1, searchDto.Products.Count);

            Assert.Equal(expected, searchDto.Products.First().Brand);
        }

        [Theory]
        [InlineData(101)]
        [InlineData(181)]
        [InlineData(88)]
        [InlineData(99)]
        [InlineData(111)]
        [InlineData(222)]
        public void GetProductByIdWithDiscount(int productId)
        {
            SearchDto searchDto = new SearchDto() { Value = productId.ToString() };

            IProductService sut = new ProductService(new ProductRepository(_fixture.DbContext),
                new ProductDomainService(),
                new ProductFactory());

            searchDto.Products = sut.Find(searchDto);

            Assert.Equal(1, searchDto.Products.Count);

            Assert.True(searchDto.Products.First().OriginalPrice > searchDto.Products.First().PriceWithDiscount);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(18)]
        [InlineData(87)]
        [InlineData(98)]
        [InlineData(12)]
        [InlineData(332)]
        public void GetProductByIdWithoutDiscount(int productId)
        {
            SearchDto searchDto = new SearchDto() { Value = productId.ToString() };

            IProductService sut = new ProductService(new ProductRepository(_fixture.DbContext),
                new ProductDomainService(),
                new ProductFactory());

            searchDto.Products = sut.Find(searchDto);

            Assert.Equal(1, searchDto.Products.Count);

            Assert.True(searchDto.Products.First().OriginalPrice == searchDto.Products.First().PriceWithDiscount);
        }

        [Theory]
        [InlineData("ibs", 8)]
        [InlineData("cni", 22)]
        [InlineData("rkh", 20)]
        public void GetProductsByBrandOrDescription(string brandOrDescription, int expected)
        {
            SearchDto searchDto = new SearchDto() { Value = brandOrDescription };

            IProductService sut = new ProductService(new ProductRepository(_fixture.DbContext),
                new ProductDomainService(),
                new ProductFactory());

            searchDto.Products = sut.Find(searchDto);

            Assert.Equal(expected, searchDto.Products.Count);
        }
    }
}