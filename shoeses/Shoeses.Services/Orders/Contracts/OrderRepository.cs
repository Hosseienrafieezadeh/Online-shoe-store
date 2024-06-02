using Shoeses.Entitis.OrderDetails;
using Shoeses.Entitis.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.Orders.Contracts
{
    public interface OrderRepository
    {
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
        Order Find(int id);
        Task<List<Order>> GetAll();
        void RemoveOrderDetail(OrderDetail orderDetail);
    }
}
