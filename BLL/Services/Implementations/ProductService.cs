using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace BLL.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Product> CreateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public Task<IEnumerable<Product>> GetBestSellerProductsAsync(int count)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetFeaturedProductsAsync(int count)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetNewArrivalsProductsAsync(int count)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> UpdateProductAsync(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
