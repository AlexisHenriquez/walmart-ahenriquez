using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using walmart_ahenriquez.Domain;

namespace walmart_ahenriquez.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly MongoDbContext _context;

        public ProductRepository(MongoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IList<Product> FindByBrandOrDescription(string brandOrDescription)
        {
            var filter = Builders<Product>.Filter.Or(
                                Builders<Product>.Filter.Regex(p => p.Brand, new BsonRegularExpression(brandOrDescription, "i")),
                                Builders<Product>.Filter.Regex(p => p.Description, new BsonRegularExpression(brandOrDescription, "i"))
                            );

            return _context.Products
                        .Find(filter)
                        .ToList();
        }

        public Product FindById(int productId)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.ProductId, productId);

            var product = _context.Products
                                .Find(filter)
                                .SingleOrDefault();

            return product;
        }
    }
}
