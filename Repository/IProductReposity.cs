using SaleService.Entities;

namespace SaleService.Repository;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts(int page, int pageSize);
    Task<Product> GetProduct(string id);
    Task<IEnumerable<Product>> GetProductByName(string name, int page, int pageSize);
    Task<IEnumerable<Product>> GetProductByCategory(string categoryName, int page, int pageSize);
    Task CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(string id);
}