using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    internal interface IUserAddressRepository : _IRepository<UserAddress>
    {
        Task<IEnumerable<UserAddress>> GetUserAddressByUserIdAsync(int userId);
    }
}
