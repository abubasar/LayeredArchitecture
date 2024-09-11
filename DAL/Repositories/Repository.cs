using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null) throw new Exception("Entity not found!!");
            return entity;
        }
        public async Task<int> PostAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            var saveChanges = await _context.SaveChangesAsync();
            return saveChanges;
        }
        public async Task<int> PutAsync(T entity)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().Update(entity);
            });
            var saveChanges = await _context.SaveChangesAsync();
            return saveChanges;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null) throw new Exception("Entity not found!!");
            await Task.Run(() =>
            {
                _context.Set<T>().Remove(entity);
            });
            var saveChanges = await _context.SaveChangesAsync();
            return saveChanges;
        }
    }
}
