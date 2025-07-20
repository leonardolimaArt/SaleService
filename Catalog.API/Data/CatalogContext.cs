namespace Catalog.API.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using Catalog.API.Entities;

    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var conn = Environment.GetEnvironmentVariable("MONGO_URL") ?? configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            var client = new MongoClient(conn);

            if (string.IsNullOrWhiteSpace(conn))
                throw new InvalidOperationException("MongoDB connection string not found.");

            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products {get;}
    }
}