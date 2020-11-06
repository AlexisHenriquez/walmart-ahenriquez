using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using walmart_ahenriquez.Infrastructure;

namespace walmart_ahenriquez.IntegrationTests
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();

            string connString = config.GetConnectionString("db");

            string dbName = "walmart-ahenriquez";

            DbContextSettings = new MongoDbContextSettings(connString, dbName);

            DbContext = new MongoDbContext(this.DbContextSettings);
        }

        public MongoDbContextSettings DbContextSettings { get; }

        public MongoDbContext DbContext { get; }

        public void Dispose()
        {
            var client = new MongoClient(this.DbContextSettings.ConnectionString);

            client.DropDatabase(this.DbContextSettings.DatabaseName);
        }
    }
}