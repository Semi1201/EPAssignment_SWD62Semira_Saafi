using Domain.Models;

namespace Domain.Interfaces
{
    public interface IMenuItemRepository
    {
        IEnumerable<MenuItem> GetAll();
        MenuItem GetById(Guid id);
    }
}
