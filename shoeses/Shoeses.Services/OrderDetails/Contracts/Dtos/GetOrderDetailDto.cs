using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.Products.Contracts.Dtos;

namespace Shoeses.Services.OrderDetails.Contracts.Dtos
{
    public class GetOrderDetailDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductId { get; set; }
        public GetProductDto Product { get; set; }
    }
}
