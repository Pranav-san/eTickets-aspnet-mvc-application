using eTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userID, string userEmailAddress);

        
        Task<List<Order>> GetOrdersByUserIdAndRole(string userID, string userRole);
    }
}
