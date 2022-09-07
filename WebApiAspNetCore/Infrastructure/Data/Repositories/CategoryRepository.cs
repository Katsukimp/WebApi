using WebApiAspNetCore.Domain.Entities;
using WebApiAspNetCore.Domain.Interfaces.Repositories;
using WebApiAspNetCore.Infrastructure.Data.Commom;
using WebApiAspNetCore.Infrastructure.Data.Repositories.Base;

namespace WebApiAspNetCore.Infrastructure.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RegisterContext context) : base(context)
        {

        }
    }
}
