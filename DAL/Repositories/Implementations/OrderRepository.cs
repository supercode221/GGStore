﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Implementations
{
    internal class OrderRepository : _BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(HoangAnhGGStoreDBContext context) : base(context)
        {
        }
    }
}
