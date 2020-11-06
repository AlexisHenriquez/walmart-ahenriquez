using System;
using System.Collections.Generic;
using System.Text;

namespace walmart_ahenriquez.Infrastructure
{
    public class MongoDbContextSettings
    {
        public MongoDbContextSettings(string connectionString, string databaseName)
        {
            ConnectionString = connectionString;

            DatabaseName = databaseName;
        }

        public string ConnectionString { get; }

        public string DatabaseName { get; }
    }
}
