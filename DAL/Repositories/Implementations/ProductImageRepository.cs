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
    internal class ProductImageRepository : _BaseRepository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(HoangAnhGGStoreDBContext context) : base(context)
        {
        }
    }
}
