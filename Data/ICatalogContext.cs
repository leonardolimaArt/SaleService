namespace SaleService.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using SaleService.Entities;

    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}