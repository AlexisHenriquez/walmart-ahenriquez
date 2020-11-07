using System;
using System.Collections.Generic;
using System.Text;
using walmart_ahenriquez.Domain;
using walmart_ahenriquez.Infrastructure;
using Xunit;

namespace walmart_ahenriquez.IntegrationTests
{
    public class ProductRepositoryShould : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;

        public ProductRepositoryShould(DatabaseFixture fixture)
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
            IProductRepository sut = new ProductRepository(_fixture.DbContext);

            Product product = sut.FindById(productId);

            Assert.Equal(expected, product.Brand);
        }

        [Theory]
        [InlineData("ibs", 8)]
        [InlineData("cni", 22)]
        [InlineData("rkh", 20)]
        public void GetProductsByBrandOrDescription(string brandOrDescription, int expected)
        {
            IProductRepository sut = new ProductRepository(_fixture.DbContext);

            IList<Product> products = sut.FindByBrandOrDescription(brandOrDescription);

            Assert.Equal(expected, products.Count);
        }
    }
}