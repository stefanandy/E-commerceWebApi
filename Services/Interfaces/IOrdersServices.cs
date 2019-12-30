using System.Collections.Generic;
using System.Threading.Tasks;
using TuringEcommerce.Models;

namespace TuringEcommerce.Services.Interfaces
{
    public interface IOrdersServices
    {
        public Task<Orders> GetOrderById(int id);
        public Task<Orders> PostOrder(string cartId, int shippingId, int taxId);
        public Task<List<Orders>> GetOrdersByCustomerId(int id);
        public Task<OrderDetail> GetOrderDetailById(int id);
    }
}