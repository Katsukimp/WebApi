namespace WebApiAspNetCore.Domain.Interfaces.Services.Base
{
    public interface IServiceBase<T>
    {
        public void Add(T entity);
        public Task AddAsync(T entity);
        public IEnumerable<T> GetAll(string?[] Tables);
        public IAsyncEnumerable<T> GetAllAsync(string?[] Tables = null);
        public T Get(Guid id);
        public Task<T> GetAsync(Guid id);
        public void Update(T entity);
        public Task UpdateAsync(T entity);
        public void Delete(Guid Id);
        public Task DeleteAsync(Guid Id);
    }
}
