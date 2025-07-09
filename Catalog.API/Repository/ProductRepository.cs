using MongoDB.Driver;
using Catalog.API.Data;
using Catalog.API.Entities;

namespace Catalog.API.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ICatalogContext _context;

    public ProductRepository(ICatalogContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProducts(int page, int pageSize)
    {
        return await _context.Products.Find(_ => true).Skip((page - 1) * pageSize).Limit(pageSize).ToListAsync();
    }

    public async Task<Product> GetProduct(string id)
    {
        return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByName(string name, int page, int pageSize)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);
        return await _context.Products.Find(filter).Skip((page - 1) * pageSize).Limit(pageSize).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName, int page, int pageSize)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
        return await _context.Products.Find(filter).Skip((page - 1) * pageSize).Limit(pageSize).ToListAsync();
    }

    public async Task CreateProduct(Product product)
    {
        await _context.Products.InsertOneAsync(product);
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var result = await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteProduct(string id)
    {
        var result = await _context.Products.DeleteOneAsync(p => p.Id == id);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }
}