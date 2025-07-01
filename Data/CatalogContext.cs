namespace SaleService.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using SaleService.Entities;

    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("ConnectionString"));
            var database = client.GetDatabase("DatabaseName");
            var products = database.GetCollection<Product>("CollectionName");
            
        }

        public IMongoCollection<Product> Products => throw new NotImplementedException();
    }
}