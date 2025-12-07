using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IRestaurantRepository _restaurantRepo;
        private readonly IMenuItemRepository _menuItemRepo;

        public CatalogController(IRestaurantRepository restaurantRepo, IMenuItemRepository menuItemRepo)
        {
            _restaurantRepo = restaurantRepo;
            _menuItemRepo = menuItemRepo;
        }

        public IActionResult Index(string type = "card")
        {
            var restaurants = _restaurantRepo.GetAll().Cast<IItemValidating>();
            var menuItems = _menuItemRepo.GetAll().Cast<IItemValidating>();

            var items = restaurants.Concat(menuItems).ToList();

            // Option to filter for pending items only for approval view:
            // items = items.Where(i => (i as dynamic).Status == "Pending").ToList();

            ViewBag.ViewType = type; // "card" or "row" to use in Catalog.cshtml
            return View("Catalog", items);
        }
    }
}
