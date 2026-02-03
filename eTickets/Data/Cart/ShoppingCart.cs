using eTickets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _Context { get; set; }

        public string ShoppingCartID { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }


        public ShoppingCart(AppDbContext Context)
        {
            _Context = Context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartID = session.GetString("CartID") ?? Guid.NewGuid().ToString();

            session.SetString("CartID", cartID);

            return new ShoppingCart(context) { ShoppingCartID = cartID };

        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _Context.ShoppingCartItems.Where(n => n.ShoppingCartID == ShoppingCartID).Include(n => n.Movie).ToList());
        }

        public double GetShoppingCartTotal()
        {
            var total = _Context.ShoppingCartItems.Where(n => n.ShoppingCartID == ShoppingCartID).Select(n => n.Movie.Price * n.Amount).Sum();
            return total;
        }

        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _Context.ShoppingCartItems.FirstOrDefault(n => n.Movie.ID == movie.ID && n.ShoppingCartID == ShoppingCartID);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartID = ShoppingCartID,
                    Movie = movie,
                    Amount = 1
                };
                _Context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _Context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _Context.ShoppingCartItems.FirstOrDefault(n => n.Movie.ID == movie.ID && n.ShoppingCartID == ShoppingCartID);
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _Context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _Context.SaveChanges();
        }
        public async Task ClearShoppingCartAsync()
        {
            var items = await _Context.ShoppingCartItems.Where(n => n.ShoppingCartID == ShoppingCartID).ToListAsync();
            _Context.ShoppingCartItems.RemoveRange(items);
            await _Context.SaveChangesAsync();

            ShoppingCartItems = new List<ShoppingCartItem>();
        }
    }
}
