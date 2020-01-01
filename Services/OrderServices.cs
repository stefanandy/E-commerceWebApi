using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TuringEcommerce.Models;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Services
{
    public class OrderServices:IOrdersServices
    {

        private readonly TuringContext _context;
        private readonly IShoppingCartServices _shoppingCartService;

        public OrderServices(TuringContext context,IShoppingCartServices shoppingCartService)
        {
            _context = context;
            _shoppingCartService = shoppingCartService;
        }
        
        public async Task<IEnumerable<Order>> GetOrderById(int id)
        {
            var orders = from o in _context.Orders
                join c in _context.Customer on o.CustomerId equals c.CustomerId
                where o.OrderId == id
                select new Order
                {
                    OrderId = o.OrderId,
                    Name = c.Name,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status,
                    ShippedOn = o.ShippedOn,
                    CreatedOn = o.CreatedOn
                };
            return await orders.ToListAsync();
        }

        public async Task<int> PostOrder(int customerId, string cartId, int shippingId, int taxId)
        {
            var order = new Orders
            {
                TotalAmount = await _shoppingCartService.GetCartTotalAmount(cartId),
                Status = 0,
                ShippingId = shippingId,
                TaxId = taxId,
                CustomerId = customerId,
                CreatedOn = DateTime.Now
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            // Line items
            var cartItems = await _shoppingCartService.GetShoppingCartById(cartId);
            foreach (var cartItem in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    ItemId = cartItem.ItemId,
                    ProductId = cartItem.ProductId,
                    Attributes = cartItem.Attributes,
                    Quantity = cartItem.Quantity,
                    ProductName = cartItem.Name,
                    UnitCost =  cartItem.Price
                };
                await _context.OrderDetail.AddAsync(orderDetail);
            }
            await _context.SaveChangesAsync();

            //Clear the cart
            await _shoppingCartService.EmptyCart(cartId);
            return order.OrderId;
        }

        public async Task<List<Order>> GetOrdersByCustomerId(int id)
        {
            var orders = from o in _context.Orders
                join c in _context.Customer on o.CustomerId equals c.CustomerId
                where o.CustomerId == id
                select new Order
                {
                    OrderId = o.OrderId,
                    Name = c.Name,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status,
                    ShippedOn = o.ShippedOn,
                    CreatedOn = o.CreatedOn
                };
            return await orders.ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            return await _context.OrderDetail.FirstOrDefaultAsync(O => O.OrderId == id);
        }
    }
}