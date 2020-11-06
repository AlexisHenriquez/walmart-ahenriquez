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

        [Fact]
        public void GetProductWithCode5()
        {
            IProductRepository sut = new ProductRepository(_fixture.DbContext);

            Product product = sut.FindById(5);

            Assert.Equal("peuoooypt", product.Brand);
        }
    }
}