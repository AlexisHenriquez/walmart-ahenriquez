using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using walmart_ahenriquez.Infrastructure;

namespace walmart_ahenriquez.IntegrationTests
{
    public class DatabaseFixture
    {
        public DatabaseFixture()
        {
            DbContext = new MongoDbContext();
        }

        public MongoDbContext DbContext { get; }

    }
}