using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoeses.Entitis.OrderDetails;
using Shoeses.Entitis.Orders;
using Shoeses.Services.Orders.Contracts;

namespace Shoeses.persistence.EF.Orders
{
    public class EFOrderRepository:OrderRepository
    {
        private readonly EFDataContext _context;

        public EFOrderRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
        }

        public Order Find(int id)
        {
            return _context.Orders
                .Include(o => o.User)
                .Include(o => o.ShippingAddress)
                .Include(o => o.ShoppingCart)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefault(o => o.Id == id);
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.ShippingAddress)
                .Include(o => o.ShoppingCart)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .ToListAsync();
        }

        public void RemoveOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Remove(orderDetail);
        }
    }
}
