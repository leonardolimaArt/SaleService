namespace Catalog.API.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using Catalog.API.Entities;

    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}