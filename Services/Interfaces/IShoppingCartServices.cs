using System.Collections.Generic;
using System.Threading.Tasks;
using TuringEcommerce.Models;

namespace TuringEcommerce.Services.Interfaces
{
    public interface IShoppingCartServices
    {
        public Task<ShoppingCart> GetShoppingCartById(int id);
        public Task AddItem(string cartId, int productId, string attributes);
        public Task UpdateItems(int itemId, int quantity);
        public Task<string> GetCartIdByItem(int itemId);
        public Task EmptyCart(string cartId);
        public Task<decimal> GetCartTotalAmount(string id);
        public Task ShoppingSaveForLater(int itemId);
        public Task MoveItemToCart(int itemId);
        public Task<List<ShoppingCart>> GetSavedCartItems(string cartId);
        public Task RemoveItem(int itemId);
    }
}