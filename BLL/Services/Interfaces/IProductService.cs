using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product?> GetProductByIdAsync(int id);

        Task<Product> CreateProductAsync(Product product);

        Task<Product?> UpdateProductAsync(int id, Product product);

        Task<bool> DeleteProductAsync(int id);

        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);

        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);

        Task<IEnumerable<Product>> GetFeaturedProductsAsync(int count);

        Task<IEnumerable<Product>> GetNewArrivalsProductsAsync(int count);

        Task<IEnumerable<Product>> GetBestSellerProductsAsync(int count);
    }
}
