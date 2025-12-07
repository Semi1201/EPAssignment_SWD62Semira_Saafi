using DataAccess.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly ApplicationDbContext _ctx;
        public MenuItemRepository(ApplicationDbContext ctx) { _ctx = ctx; }

        public IEnumerable<MenuItem> GetAll()
        {
            // Include the Restaurant so GetValidators() has Restaurant.OwnerEmailAddress
            return _ctx.MenuItems
                       .Include(mi => mi.Restaurant)
                       .AsNoTracking()
                       .ToList();
        }

        public MenuItem GetById(Guid id)
        {
            return _ctx.MenuItems
                       .Include(mi => mi.Restaurant)
                       .AsNoTracking()
                       .FirstOrDefault(mi => mi.Id == id);
        }
    }
}
