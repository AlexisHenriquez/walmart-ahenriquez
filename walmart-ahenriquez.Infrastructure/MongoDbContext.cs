using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Diagnostics;
using System.IO;
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
                cm.MapMember(p => p.ProductId).SetElementName("id");
                cm.MapMember(p => p.Brand).SetElementName("brand");
                cm.MapMember(p => p.Description).SetElementName("description");
                cm.MapMember(p => p.Image).SetElementName("image");
                cm.MapMember(p => p.Price).SetElementName("price");

                cm.SetIgnoreExtraElements(true);
            });
        }

        public MongoDbContext()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var isDevelopment = environment == Environments.Development;

            string currentPath = string.Empty;
            
            if (isDevelopment)
            {
                currentPath = Directory.GetCurrentDirectory();
            }
            else
            {
                using var processModule = Process.GetCurrentProcess().MainModule;

                currentPath = Path.GetDirectoryName(processModule?.FileName);
            }
            
            var config = new ConfigurationBuilder()
                .SetBasePath(currentPath)
                .AddJsonFile("appSettings.json")
                .Build();

            var client = new MongoClient(config.GetConnectionString("dbConnection"));

            _database = client.GetDatabase(config.GetConnectionString("dbName"));
        }

        public IMongoCollection<Product> Products { get { return _database.GetCollection<Product>("products"); } }
    }
}
