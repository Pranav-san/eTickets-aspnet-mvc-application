using eTickets.Data.Cart;
using eTickets.Data.Services;
using eTickets.Data.View_Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMovieService _moviesService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;

        public OrdersController(IMovieService moviesService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _moviesService = moviesService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var respone = new ShoppingCartVM()
            {
                ShoppingCart= _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()

            };
            return View(respone);
        }

        public async Task<IActionResult> AddToShoppingCart(int ID)
        {
            var item = await _moviesService.GetMovieByIdAsync(ID);

            if(item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));

        }
        public async Task<IActionResult> RemoveItemShoppingCart(int ID)
        {
            var item = await _moviesService.GetMovieByIdAsync(ID);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));

        }
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            string userID = "";
            string userEmailAddress = "";

            await _ordersService.StoreOrderAsync(items, userID, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");



        }


    }
}
