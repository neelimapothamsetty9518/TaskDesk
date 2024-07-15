using Microsoft.EntityFrameworkCore;
using TravelDeskWebapi.IRepoManager;
using TravelDeskWebapi.Model;
using TravelDeskWebapi.NewFolder;


namespace TravelDeskWebapi
{
    public class ManagerRepo:ManagerInterface
    {
        private ManagerDbContext _context;
        public ManagerRepo(ManagerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Manager>> GetAllAsync()
        {
            return await _context.managers.ToListAsync();
        }

        public async Task<Manager> GetByIdAsync(int id)
        {
            return await _context.managers.FindAsync(id);
        }

        public async Task<Manager> AddAsync(Manager m)
        {
            _context.managers.Add(m);
            await _context.SaveChangesAsync();
            return m;
        }

        public async Task UpdateAsync(Manager m)
        {
            _context.Entry(m).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await _context.managers.FindAsync(id);
            if (obj != null)
            {
                _context.managers.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.managers.AnyAsync(e => e.Id == id);
        }
    }
}

