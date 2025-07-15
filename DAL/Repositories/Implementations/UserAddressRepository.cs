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
    internal class UserAddressRepository : _BaseRepository<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(HoangAnhGGStoreDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserAddress>> GetUserAddressByUserIdAsync(int userId)
        {
            return await _dbSet.Where(ua => ua.UserId == userId).ToListAsync();
        }
    }
}
