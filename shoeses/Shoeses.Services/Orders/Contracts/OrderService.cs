using Shoeses.Entitis.Payments;
using Shoeses.Services.Orders.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.Orders.Contracts
{
    public interface  OrderService
    {
        Task Add(AddOrderDto dto);
        Task Update(int id, UpdateOrderDto dto);
        Task Delete(int id);
        Task<List<GetOrderDto>> GetAll();
        Task<GetOrderDto> GetById(int id);
        Task AddPayment(int orderId, Payment payment); // Add this line
        Task<List<Payment>> GetPaymentsByOrderId(int orderId); // Add this line
    }
}
