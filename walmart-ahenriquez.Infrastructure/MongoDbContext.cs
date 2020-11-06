using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using walmart_ahenriquez.Domain;

namespace walmart_ahenriquez.Infrastructure
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        static MongoDbContext()
        {
            BsonClassMap.RegisterClassMap<Product>(cm =>
            {
                cm.AutoMap();

                cm.MapIdMember(p => p.Id);
                cm.MapMember(p => p.IdProducto).SetElementName("id");
                cm.MapMember(p => p.Brand).SetElementName("brand");
                cm.MapMember(p => p.Description).SetElementName("description");
                cm.MapMember(p => p.Image).SetElementName("image");
                cm.MapMember(p => p.Price).SetElementName("price");

                cm.SetIgnoreExtraElements(true);
            });
        }

        public MongoDbContext(MongoDbContextSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);

            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<Product> Products { get { return _database.GetCollection<Product>("products"); } }
    }
}
