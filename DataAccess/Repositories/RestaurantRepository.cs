using DataAccess.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext _ctx;
        public RestaurantRepository(ApplicationDbContext ctx) { _ctx = ctx; }

        public IEnumerable<Restaurant> GetAll()
        {
            return _ctx.Restaurants.AsNoTracking().ToList();
        }

        public Restaurant GetById(int id)
        {
            return _ctx.Restaurants
                       .Include(r => r.MenuItems)
                       .AsNoTracking()
                       .FirstOrDefault(r => r.Id == id);
        }
    }
}
