using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TuringEcommerce.Models;
using TuringEcommerce.Services.Interfaces;


namespace TuringEcommerce.Services
{
    public class ShoppingCartServices:IShoppingCartServices
    {

        private readonly TuringContext _context;

        public ShoppingCartServices(TuringContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartProduct>> GetShoppingCartById(string id)
        {
            var filteredCart = _context.ShoppingCart.Where(i => i.CartId == id && i.BuyNow == true).ToList();

            var cart = from c in filteredCart
                join p in _context.Product on c.ProductId equals p.ProductId
                group new {c, p} by p.ProductId
                into grouping
                select new CartProduct
                {
                    ItemId = grouping.First().c.ItemId,
                    ProductId = grouping.Key,
                    Attributes = grouping.First().c.Attributes,
                    Quantity = grouping.First().c.Quantity,
                    Name = grouping.First().p.Name,
                    Price = (grouping.First().p.DiscountedPrice > 0 ? grouping.First().p.DiscountedPrice : grouping.First().p.Price ).ToString(CultureInfo.InvariantCulture),
                    SubTotal = (grouping.First().c.Quantity * (grouping.First().p.DiscountedPrice > 0 ? grouping.First().p.DiscountedPrice : grouping.First().p.Price))
                        .ToString(CultureInfo.InvariantCulture)
                };
            
            var summary = await Task.FromResult(cart.ToList());
            return summary;
        }

        public async Task AddItem(string cartId, int productId, string attributes)
        {
            var item = _context
                .ShoppingCart
                .FirstOrDefault(c => c.ProductId == productId && c.CartId == cartId);

            if (item != null)
            {
                await UpdateItems(item.ItemId, item.Quantity + 1);
            }
            else
            {
                var newCartItem = new ShoppingCart
                {
                    CartId = cartId,
                    ProductId = productId,
                    Attributes = attributes,
                    AddedOn = DateTime.Now,
                    Quantity = 1,
                    BuyNow = true
                };

                _context.ShoppingCart.Add(newCartItem);
                await _context.SaveChangesAsync();
            }
        }
        
        public async Task UpdateItems(int itemId, int quantity)
        {
            var item = _context.ShoppingCart.First(c => c.ItemId == itemId);

            item.Quantity = quantity;
            item.AddedOn = DateTime.Now;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<string> GetCartIdByItem(int itemId)
        {
            var cart = await _context.ShoppingCart.FirstOrDefaultAsync(c => c.ItemId == itemId);
            return cart?.CartId;
        }

        public async Task EmptyCart(string cartId)
        {
            var cartItems = _context.ShoppingCart.Where(c => c.CartId == cartId && c.BuyNow == true);
            foreach (var item in cartItems) 
                _context.Entry(item).State = EntityState.Deleted;
            
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetCartTotalAmount(string id)
        {
            var cartWithProducts = from pc in _context.ShoppingCart
                join c in _context.Product on pc.ProductId equals c.ProductId
                where pc.CartId == id
                select new
                {
                    pc.Quantity,
                    c.Price,
                    c.DiscountedPrice
                };

            var total = await cartWithProducts.SumAsync(c => c.Quantity * (c.DiscountedPrice > 0 ? c.DiscountedPrice : c.Price));
            return total;
        }

        public async Task ShoppingSaveForLater(int itemId)
        {
            var item = _context.ShoppingCart
                .First(c => c.ItemId == itemId);

            item.BuyNow = false;
            item.Quantity = 1;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task MoveItemToCart(int itemId)
        {
            var item = _context
                .ShoppingCart
                .First(c => c.ItemId == itemId);

            item.BuyNow = true;
            item.AddedOn = DateTime.Now;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<ShoppingCart>> GetSavedCartItems(string cartId)
        {
            var products = from pc in _context.ShoppingCart
                join c in _context.Product on pc.ProductId equals c.ProductId
                where pc.CartId == cartId && pc.BuyNow == false
                select pc;

            return await products.ToListAsync();
        }

        public async Task RemoveItem(int itemId)
        {
            var cart = _context
                .ShoppingCart
                .Where(c => c.ItemId == itemId);
            foreach (var item in cart) 
                _context.Entry(item).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}