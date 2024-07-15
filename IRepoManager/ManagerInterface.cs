using TravelDeskWebapi.Model;

namespace TravelDeskWebapi.IRepoManager
{
    public interface ManagerInterface
    {

        Task<IEnumerable<Manager>> GetAllAsync();
        Task<Manager> GetByIdAsync(int id);
        Task<Manager> AddAsync(Manager manager);
        Task UpdateAsync(Manager manager);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
