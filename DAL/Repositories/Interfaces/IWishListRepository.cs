using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    internal interface IWishListRepository : _IRepository<Wishlist>
    {
        Task<IEnumerable<Wishlist>> GetWishListItemsByUserIdAsync(int userId);

        Task<IEnumerable<Wishlist>> GetWishlistItemsByProductIdAsync(int wishlistId);

        Task<IEnumerable<Wishlist>> GetWishlistItemsByVariantIdAsync(int variantId);
    }
}
