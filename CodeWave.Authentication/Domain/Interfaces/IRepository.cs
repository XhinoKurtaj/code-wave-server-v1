namespace CodeWave.Authentication.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        IQueryable<T> TableNoTracking { get; }
        IQueryable<T> Table { get; set; }
    }
}
