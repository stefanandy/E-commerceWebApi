using System.Collections.Generic;
using System.Threading.Tasks;
using TuringEcommerce.Models;

namespace TuringEcommerce.Services.Interfaces
{
    public interface IOrdersServices
    {
        public Task<IEnumerable<Order>> GetOrderById(int id);
        public Task<int> PostOrder(int cutomerID, string cartId, int shippingId, int taxId);
        public Task<List<Order>> GetOrdersByCustomerId(int id);
        public Task<OrderDetail> GetOrderDetailById(int id);
    }
}