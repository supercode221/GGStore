using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    internal class WishListRepository : _BaseRepository<Wishlist>, IWishListRepository
    {
        public WishListRepository(HoangAnhGGStoreDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Wishlist>> GetWishlistItemsByProductIdAsync(int wishlistId)
        {
            return await _dbSet.Where(w => w.WishlistId == wishlistId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Wishlist>> GetWishListItemsByUserIdAsync(int userId)
        {
            return await _dbSet.Where(w => w.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Wishlist>> GetWishlistItemsByVariantIdAsync(int variantId)
        {
               return await _dbSet.Where(w => w.VariantId == variantId)
                .ToListAsync();
        }
    }
}
