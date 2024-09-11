namespace DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<int> DeleteAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> PostAsync(T entity);
        Task<int> PutAsync(T entity);
    }
}