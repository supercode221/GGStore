using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Implementations
{
    internal class ProductRepository : _BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(HoangAnhGGStoreDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetBestSellerProductsAsync(int count)
        {
            //return await _context.Products
            //    .Where(p => p.IsBestSeller)
            //    .OrderByDescending(p => p.SalesCount)
            //    .Take(count)
            //    .ToListAsync();
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

        public Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
