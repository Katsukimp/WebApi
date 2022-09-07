using WebApiAspNetCore.Domain.Entities.Base;

namespace WebApiAspNetCore.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T> where T : BaseModel
    {
        public void Add(T entity);
        public Task AddAsync(T entity);
        public IEnumerable<T> GetAll();
        public IAsyncEnumerable<T> GetAllAsync();
        public T Get(Guid id);
        public Task<T> GetAsync(Guid id);
        public void Update(T entity);
        public Task UpdateAsync(T entity);
        public void Delete(Guid id);
        public Task DeleteAsync(Guid id);
        public void Include(string? child);
    }
}
