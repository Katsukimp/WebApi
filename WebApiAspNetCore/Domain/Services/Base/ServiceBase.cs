using System.Linq;
using WebApiAspNetCore.Domain.Entities.Base;
using WebApiAspNetCore.Domain.Interfaces.Repositories.Base;
using WebApiAspNetCore.Domain.Interfaces.Services.Base;

namespace WebApiAspNetCore.Domain.Services.Base
{
    public class ServiceBase<T> : IServiceBase<T> where T : BaseModel
    {
        protected readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }
    
        public void Add(T entity) => _repository.Add(entity);

        public Task AddAsync(T entity) => _repository.AddAsync(entity);

        public void Delete(Guid Id) => _repository.Delete(Id);

        public Task DeleteAsync(Guid Id) => _repository.DeleteAsync(Id);

        public T Get(Guid id) => _repository.Get(id);

        public IEnumerable<T> GetAll(string?[] Tables)
        {
            var result = _repository.GetAll();

            if (Tables is not null)
            {
                foreach (var child in Tables)
                {
                    _repository.Include(child);
                }
            }

            return result;
        }

        public IAsyncEnumerable<T> GetAllAsync(string?[] Tables = null)
        {
            var result = _repository.GetAllAsync();

            if (Tables is not null)
            {
                foreach (var child in Tables)
                {
                    _repository.Include(child);
                }
            }

            return result;
        }

        public Task<T> GetAsync(Guid id) => _repository.GetAsync(id);

        public void Update(T entity) => _repository.Update(entity);

        public Task UpdateAsync(T entity) => _repository.UpdateAsync(entity);
    }
}
