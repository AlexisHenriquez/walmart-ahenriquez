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
            var values = new List<string>() { brandOrDescription };

            var filter = Builders<Product>.Filter.Or(
                                Builders<Product>.Filter.In(p => p.Brand, values),
                                Builders<Product>.Filter.In(p => p.Description, values)
                            );

            return _context.Products
                        .Find(filter)
                        .ToList();
        }

        public Product FindById(int id)
        {
            var product = _context.Products
                                .AsQueryable()
                                .Where(p => p.Id == id)
                                .SingleOrDefault();

            return product;
        }
    }
}
