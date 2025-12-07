using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetById(int id);
    }
}
